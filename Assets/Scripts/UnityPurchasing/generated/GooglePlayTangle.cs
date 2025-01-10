// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("+UvI6/nEz8DjT4FPPsTIyMjMycrVygDDSuzmdEmG7d3y4j3Z2LbAXFuj1JgPh5KsHy/AKBCEZLWNLyKAlkCIKnO+44UX51JOaWQ5wGsvZg7LEyoFk8bCVxpmFkP5FxyFmM6qyvJ6etAyvIWoRXiSg7ffxL5UTovekvwpuncvdH4Ux8/ie6WRS7lrEeqVjsuaUYW1JeFHog/cknkVARKiBEvIxsn5S8jDy0vIyMloodfXLsZFa2F11LsE+b8Q86GNdcTUm11EUzrRBBGxnyzznExZoAyPkr6avc2hnsnnKfxCwxnmEFABSb/4PN3zZwp6VkkI832mpzaoFFdenirFzyoWxgROA0j8dripAU2hjnd4L6nNuTbPo3p+CKGdvk3ZvsvKyMnI");
        private static int[] order = new int[] { 0,11,7,12,13,6,6,9,11,12,12,13,12,13,14 };
        private static int key = 201;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
