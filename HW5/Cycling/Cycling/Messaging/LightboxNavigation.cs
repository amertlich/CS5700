using System;

namespace Cycling.Messaging
{
    public static class LightboxNavigation
    {
        public static string Token = Guid.NewGuid().ToString();
        public const string SELECT_RACE = "SelectRace";
        public const string CLOSE_Lightbox = "CloseLightbox";
    }
}
