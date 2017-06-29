namespace App.Mvc.Resources
{
    using System;
    using System.Collections.Generic;

    public class SiteText
    {
        private IDictionary<string, string> Text = new Dictionary<string, string>();

        public static SiteText Instance = new SiteText();

        private SiteText()
        {
            LoadErrorMessages(Text);
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public string GetString(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            if (Text.ContainsKey(s)) return Text[s];
            return s;
        }

        /// <summary>
        /// Loads the error messages.
        /// </summary>
        /// <param name="text">The text.</param>
        private static void LoadErrorMessages(IDictionary<string, string> text)
        {
			text["account_username_missing"] = "Username is missing" ;

			text["account_username_invalid"] = "Username is invalid";
			text["account_password_missing"] = "Password is missing" ;

			text["account_password_invalid"] = "Password is invalid";
			text["account_lastloggedin_missing"] = "Last Logged In is missing" ;

			text["account_lastloggedin_invalid"] = "Last Logged In is invalid";
			text["account_loginattempts_missing"] = "Login Attempts is missing" ;

			text["account_loginattempts_invalid"] = "Login Attempts is invalid";
			text["account_islockedout_missing"] = "Is Locked Out is missing" ;

			text["account_islockedout_invalid"] = "Is Locked Out is invalid";
			text["account_accountvalidfrom_missing"] = "Account Valid From is missing" ;

			text["account_accountvalidfrom_invalid"] = "Account Valid From is invalid";
			text["account_accountvalidto_missing"] = "Account Valid To is missing" ;

			text["account_accountvalidto_invalid"] = "Account Valid To is invalid";
			text["account_loginstartat_missing"] = "Login Start At is missing" ;

			text["account_loginstartat_invalid"] = "Login Start At is invalid";
			text["account_loginuntil_missing"] = "Login Until is missing" ;

			text["account_loginuntil_invalid"] = "Login Until is invalid";
			text["right_name_missing"] = "Name is missing" ;

			text["right_name_invalid"] = "Name is invalid";
			text["right_key_missing"] = "Key is missing" ;

			text["right_key_invalid"] = "Key is invalid";
			text["right_isassignable_missing"] = "Is Assignable is missing" ;

			text["right_isassignable_invalid"] = "Is Assignable is invalid";
			text["role_name_missing"] = "Name is missing" ;

			text["role_name_invalid"] = "Name is invalid";
			text["role_key_missing"] = "Key is missing" ;

			text["role_key_invalid"] = "Key is invalid";
			text["role_isassignable_missing"] = "Is Assignable is missing" ;

			text["role_isassignable_invalid"] = "Is Assignable is invalid";
        }
    }
}