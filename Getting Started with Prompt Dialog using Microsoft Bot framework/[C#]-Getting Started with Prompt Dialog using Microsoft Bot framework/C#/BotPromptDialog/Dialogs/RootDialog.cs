using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace BotPromptDialog.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            //Show the title with background image and Details
            var message = context.MakeMessage();
            var attachment = GetHeroCard();
            message.Attachments.Add(attachment);
            await context.PostAsync(message);

            // Show the list of plan
            context.Wait(this.ShowAnnuvalConferenceTicket);
            //  return Task.CompletedTask;
        }

        /// <summary>
        /// Design Title with Image and About US link
        /// </summary>
        /// <returns></returns>
        private static Attachment GetHeroCard()
        {
            var heroCard = new HeroCard
            {
                Title = "Annual Conference 2018 Registrtion ",
                Subtitle = "DELHI, 13 - 15 APRIL 2018",
                Text = "The C# Corner Annual Conference 2018 is a three-day annual event for software professionals and developers. First day is exclusive for C# Corner MVPs only. The second day is open to the public, and includes presentations from many top names in the industry. The third day events are, again, exclusively for C# Corner MVPs",
                Images = new List<CardImage> { new CardImage("https://lh3.googleusercontent.com/-fnwLMmJTmdk/WaVt5LR2OZI/AAAAAAAAG90/qlltsHiSdZwVdOENv1yB25kuIvDWCMvWACLcBGAs/h120/annuvalevent.PNG") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "About US", value: "http://conference.c-sharpcorner.com/") }
            };

            return heroCard.ToAttachment();
        }

        public virtual async Task ShowAnnuvalConferenceTicket(IDialogContext context, IAwaitable<IMessageActivity> activity)
        {
            var message = await activity;
         
            PromptDialog.Choice(
                context: context,
                resume: ChoiceReceivedAsync,
                options: (IEnumerable<AnnuvalConferencePass>)Enum.GetValues(typeof(AnnuvalConferencePass)),
                prompt: "Hi. Please Select Annuval Conference 2018 Pass :",
                retry: "Selected plan not avilabel . Please try again.",
                promptStyle: PromptStyle.Auto
                );
        }
        public virtual async Task ChoiceReceivedAsync(IDialogContext context, IAwaitable<AnnuvalConferencePass> activity)
        {
            AnnuvalConferencePass response = await activity;
            context.Call<object>(new AnnualPlanDialog(response.ToString()), ChildDialogComplete);

        }
        public virtual async Task ChildDialogComplete(IDialogContext context, IAwaitable<object> response)
        {
            await context.PostAsync("Thanks for select C# Corner bot for Annual Conference 2018 Registrion .");
            context.Done(this);
        }

        public enum AnnuvalConferencePass
        {
            EarlyBird,
            Regular,
            DelegatePass,
            CareerandJobAdvice,
        }
    }
}