namespace SchoolProject.Shared.Network.Constants
{
    public enum ClientOpcodes
    {
        RequestProducts     = 0x01,
        RequestCategories   = 0x02,
    }

    public enum ServerOpcodes
    {
        ResponseProducts    = 0x01,
        ResponseCategories  = 0x02,
    }
}
