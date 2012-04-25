using System;
using System.Text;

namespace GalaxySmash
{
    public static class ExtenstionMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exc"></param>
        /// <returns></returns>
        public static string ToPrettyString(this Exception exc)
        {
            try
            {
                var messageBuilder = new StringBuilder();

                messageBuilder.AppendFormat("Message: '{0}'\nSource: '{1}'\nTrace: '{2}'",
                    exc.Message, exc.Source, exc.StackTrace);

                if ((exc is StackOverflowException) == false)
                {
                    if (exc.InnerException != null)
                        messageBuilder.Append('\n' + ToPrettyString(exc.InnerException));
                }

                return messageBuilder.ToString();
            }
            catch (Exception exc2)
            {
                try
                {
                    string errorMessage = string.Format("Error while getting pretty string. Message: {0}\n", exc2.Message);

                    Log.Error(errorMessage);

                    return errorMessage;
                }
                catch (Exception)
                {
                    return "Good god, you've broken the error handler for the error handler's error handler.";
                }
            }
        }

        public static void Clear(this StringBuilder sb)
        {
            int length = sb.ToString().Length;

            if (length == 0)
                return;

            sb.Remove(0, length);
        }
    }
}
