namespace FastAndroidAPI.Models
{
    using System;

    public partial class MultiTenant
    {
        public int ClientID { get; set; }
        public string ClientConnString { get; set; }
        public string BackGroundImage { get; set; }
        public string Logo { get; set; }
    }
}