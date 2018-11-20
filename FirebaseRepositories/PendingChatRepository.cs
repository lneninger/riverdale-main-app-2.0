using ApplicationLogic.Business.Commands.Chat.ListenPendingChatCommand.DTOs;
using FocusApplication.Repositories.Firebase;
using System;
using System.Collections.Generic;
using System.Text;
//using Firebase.Database;
//using Firebase.Database.Query;

namespace FirebaseRepositories
{
    public class PendingChatRepository : BaseRepository, IPendingChatRepository
    {
        public PendingChatRepository()
        {
        }

        public const string PendingChatTable = "pending-chats";

        public event NewPendingChatDelegate NewPendingChatEvent;

        public bool InitListening() {

            var client = this.CreateFirebaseClient();
            client.Child(PendingChatTable).AsObservable<PendingChatDTO>().Subscribe(observer =>
            {
                this.NewPendingChatEvent.Invoke(observer.Object);
            });

            return true;
        }
    }
}
