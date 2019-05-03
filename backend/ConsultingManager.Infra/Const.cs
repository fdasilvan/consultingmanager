using System;

namespace ConsultingManager.Infra
{
    public static class Const
    {
        public static class UserType
        {
            public static Guid Administrator
            {
                get
                {
                    return Guid.Parse("D10DD961-E131-4618-A235-8B0116AECC91");
                }
            }

            public static Guid Consultant
            {
                get
                {
                    return Guid.Parse("70F24307-54B9-41E3-B4FB-4C86E0202BA4");
                }
            }

            public static Guid Leader
            {
                get
                {
                    return Guid.Parse("5F70A257-25A9-42E4-9DB3-8623D6E758A5");
                }
            }

            public static Guid Customer
            {
                get
                {
                    return Guid.Parse("43C2E87C-35A8-47C0-A4DD-D233B836DD4A");
                }
            }
        }
    }
}
