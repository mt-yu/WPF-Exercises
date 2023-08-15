using MyToDo.UsePrism.Temp.Services.Interfaces;

namespace MyToDo.UsePrism.Temp.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
