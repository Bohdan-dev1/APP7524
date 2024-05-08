using App75241305.Engine;

namespace App75241305.Engine

{
    internal class Engine
    {
        public void Main()
        {
            VkAPI vkAPI = new VkAPI();
            if (!vkAPI.GetStatusInit()) {
                Console.WriteLine("");
            }
        }
    }
}
