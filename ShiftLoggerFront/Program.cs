
using System;


namespace ShiftLoggerFront
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await UserMenus.ShowUserOptions();
        }
    }
}