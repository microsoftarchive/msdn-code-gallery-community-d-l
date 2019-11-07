namespace ClientSample.Ftp.Security
{
    static class CertTextExtractor
    {
        public static void Extract(string name, out string commonName, out string countryCode, out string state, out string city, out string organization, out string unit, out string email)
        {
            commonName = countryCode = state = city = organization = unit = email = string.Empty;
            string[] arr = name.Split(',');
            foreach (string s in arr)
            {
                string[] pair = s.TrimStart(' ').Split('=');
                switch (pair[0])
                {
                    case "CN":
                        commonName = pair[1];
                        break;

                    case "C":
                        countryCode = pair[1];
                        break;

                    case "S":
                        state = pair[1]; break;

                    case "L":
                        city = pair[1]; break;

                    case "O":
                        organization = pair[1]; break;

                    case "OU":
                        unit = pair[1]; break;

                    case "E":
                        email = pair[1]; break;
                }
            }
        }
    }
}
