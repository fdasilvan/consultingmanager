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

            public static Guid Implanter
            {
                get
                {
                    return Guid.Parse("BB159ACC-CB7D-476D-9C45-1A75DAFED934");
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

            public static Guid Specialist
            {
                get
                {
                    return Guid.Parse("26C152BE-CEDD-4C77-90F5-69F986D600F2");
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

        public static class Teams
        {
            public static Guid Implantation
            {
                get
                {
                    return Guid.Parse("7F186FCA-EEB3-48D8-A0F0-7387545EB60D");
                }
            }

            public static Guid Consulting
            {
                get
                {
                    return Guid.Parse("EEDCAAC4-6DB4-4BB1-B102-5493D0116183");
                }
            }
        }

        public static class CustomerSituations
        {
            public static Guid Active
            {
                get
                {
                    return Guid.Parse("DD57B16A-CCF9-4DA1-8D3B-D24E59251AFF");
                }
            }

            public static Guid Paused
            {
                get
                {
                    return Guid.Parse("11A6435D-BE18-4427-AF65-428EEF70C23B");
                }
            }

            public static Guid Blocked
            {
                get
                {
                    return Guid.Parse("3668344D-2BFA-4C36-AA91-5D7A42CB651F");
                }
            }

            public static Guid Canceled
            {
                get
                {
                    return Guid.Parse("EB71C684-A336-4985-A50F-923B3F439387");
                }
            }

            public static Guid ContractCompleted
            {
                get
                {
                    return Guid.Parse("241B42EA-05C7-4E7F-81B0-758A688E1A56");
                }
            }
        }

        public static class ContractSituations
        {
            public static Guid Active
            {
                get
                {
                    return Guid.Parse("92B405A1-7EC7-4310-8EF3-BE7C4040A94A");
                }
            }

            public static Guid Paused
            {
                get
                {
                    return Guid.Parse("7EC78F62-0A7F-4FDA-BFF4-6819E724A8E1");
                }
            }

            public static Guid Blocked
            {
                get
                {
                    return Guid.Parse("9BE12448-E253-4C47-AE0D-3F69DE0D023A");
                }
            }

            public static Guid Canceled
            {
                get
                {
                    return Guid.Parse("BD944220-6985-4BAD-A7AF-80BBD1BF1084");
                }
            }

            public static Guid Completed
            {
                get
                {
                    return Guid.Parse("CB7F761D-DFC6-4BDA-A061-239B607D384E");
                }
            }
        }

        public static class MeetingTypes
        {
            public static Guid Implantation
            {
                get
                {
                    return Guid.Parse("0A5D9561-6518-47A5-89F3-034F4D0256CD");
                }
            }

            public static Guid Consulting
            {
                get
                {
                    return Guid.Parse("38CBB2DD-E1A9-4535-A00A-DCD81CF4FD82");
                }
            }

            public static Guid Review
            {
                get
                {
                    return Guid.Parse("C203D729-D70A-4BB8-853A-879EF62DABE1");
                }
            }
        }
    }
}
