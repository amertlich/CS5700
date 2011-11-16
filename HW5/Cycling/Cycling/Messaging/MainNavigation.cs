using System;

namespace Cycling.Messaging
{
   public static class MainNavigation
   {
      public static string Token = Guid.NewGuid().ToString();
      public const string MAIN_MENU = "MainMenu";
   }
}