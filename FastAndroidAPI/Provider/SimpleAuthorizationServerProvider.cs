using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FastAndroidAPI.Provider
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            CORNAttendanceApi.Models.EncryptDecrypt decrypt = new CORNAttendanceApi.Models.EncryptDecrypt();
            IHeaderDictionary headers = context.Request.Headers;
            if (!headers.ContainsKey("x-conn"))
                throw new UnauthorizedAccessException("You are not authorized to access this link. Please contact administrator");

            string connStr = headers["x-conn"];
            string encryptkey = "";
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);


            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var db = new dbSAMSAndroidEntities())
            {
                db.Database.Connection.ConnectionString = decrypt.DecryptValue(connStr);
                if (db != null)
                {
                    var user = db.uspGetUSERSAndroid(context.UserName).ToList();
                    if (user != null)
                    {
                        if (user.Count > 0)
                        {
                            bool IsVerified = false;
                            for (int i = 0; i < user.Count; i++)
                            {
                                if (user[i].IsEncrypted)
                                {
                                    if(user[i].EncryptKey.ToString().Length > 0)
                                    {
                                        encryptkey = decrypt.DecryptValue(user[i].EncryptKey);
                                        if (user[i].UserLogin == context.UserName && decrypt.DecryptValue(user[i].UserPassword, encryptkey) == context.Password)
                                        {
                                            var props = new AuthenticationProperties(new Dictionary<string, string>
                                        {
                                            {
                                                "UserLogin", user[i].UserLogin
                                            },
                                            {
                                                "UserPassword",user[i].UserPassword
                                            },
                                            {
                                                "UserId", user[i].UserID.ToString()
                                            },
                                            {
                                                "UserName", user[i].UserName.ToString()
                                            },
                                            {
                                                "DistributionID",user[i].DistributionID.ToString()
                                            },
                                            {
                                                "DistributorTypeID", user[i].DistributorTypeID.ToString()
                                            },
                                            {
                                                "DistributorName", user[i].DistributorName
                                            },
                                            {
                                                "IsDistributorRegister",user[i].IsDistributorRegister.ToString()
                                            },
                                            {
                                                "RoleID",user[i].IsDistributorRegister.ToString()
                                            }
                                            ,
                                            {
                                                "OTPicturesManadatory",user[i].OTPicturesManadatory.ToString()
                                            }
                                        });
                                            var ticket = new AuthenticationTicket(identity, props);

                                            context.Validated(ticket);
                                            IsVerified = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        context.SetError("invalid_grant : Provided username and password is incorrect", "Provided username and password is incorrect");
                                        context.Rejected();
                                    }
                                }
                                else
                                {
                                    if (user[i].UserLogin == context.UserName && user[i].UserPassword == context.Password)
                                    {
                                        var props = new AuthenticationProperties(new Dictionary<string, string>
                                        {
                                            {
                                                "UserLogin", user[i].UserLogin
                                            },
                                            {
                                                "UserPassword",user[i].UserPassword
                                            },
                                            {
                                                "UserId", user[i].UserID.ToString()
                                            },
                                            {
                                                "UserName", user[i].UserName.ToString()
                                            },
                                            {
                                                "DistributionID",user[i].DistributionID.ToString()
                                            },
                                            {
                                                "DistributorTypeID", user[i].DistributorTypeID.ToString()
                                            },
                                            {
                                                "DistributorName", user[i].DistributorName
                                            },
                                            {
                                                "IsDistributorRegister",user[i].IsDistributorRegister.ToString()
                                            },
                                            {
                                                "RoleID",user[i].IsDistributorRegister.ToString()
                                            }
                                            ,
                                            {
                                                "OTPicturesManadatory",user[i].OTPicturesManadatory.ToString()
                                            }
                                        });
                                        var ticket = new AuthenticationTicket(identity, props);

                                        context.Validated(ticket);
                                        IsVerified = true;
                                        break;
                                    }
                                }
                            }
                            if (!IsVerified)
                            {
                                context.SetError("invalid_grant : Provided username and password is incorrect", "Provided username and password is incorrect");
                                context.Rejected();
                            }
                        }
                        else
                        {
                            context.SetError("invalid_grant", "Provided username and password is incorrect");
                            context.Rejected();
                        }
                    }
                    else
                    {
                        context.SetError("invalid_grant", "Provided username and password is incorrect");
                        context.Rejected();
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    context.Rejected();
                }
                return;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}