using System;

namespace ConsultingManager.Infra
{
    public static class Const
    {
        public static class UserTypes
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

        public static class TaskTypes
        {
            public static Guid Customer
            {
                get
                {
                    return Guid.Parse("A26F516B-6A6F-4159-8F4E-6CA3193BEA95");
                }
            }

            public static Guid Consultant
            {
                get
                {
                    return Guid.Parse("E84138FE-A7C6-4724-865F-1C4CAB8BE234");
                }
            }
        }

        public static class Platforms
        {
            public static Guid Simplo7
            {
                get
                {
                    return Guid.Parse("7B64054E-FC81-44E1-A1E2-CFB4BFCF8489");
                }
            }
        }
    }
}
