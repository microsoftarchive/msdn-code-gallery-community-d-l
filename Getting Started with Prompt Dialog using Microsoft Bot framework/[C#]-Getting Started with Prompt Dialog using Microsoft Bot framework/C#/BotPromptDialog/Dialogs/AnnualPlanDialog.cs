using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotPromptDialog.Dialogs
{
    [Serializable]
    public class AnnualPlanDialog : IDialog<object>
    {
        string name;
        string email;
        string phone;
        string plandetails;
        public AnnualPlanDialog(string plan)
        {
            plandetails = plan;
        }
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Thanks for Select "+ plandetails + " Plan , Can I Help for Registrtion ? ");
           
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> activity)
        {
            var response = await activity;
            if (response.Text.ToLower().Contains("yes"))
            {
                PromptDialog.Text(
                    context: context,
                    resume: ResumeGetName,
                    prompt: "Please share your good name",
                    retry: "Sorry, I didn't understand that. Please try again."
                );
            }
            else
            {
                context.Done(this);
            }
            
        }

        public virtual async Task ResumeGetName(IDialogContext context, IAwaitable<string> Username)
        {
            string response = await Username;
            name = response; ;

            PromptDialog.Text(
                context: context,
                resume: ResumeGetEmail,
                prompt: "Please share your Email ID",
                retry: "Sorry, I didn't understand that. Please try again."
            );
        }

        public virtual async Task ResumeGetEmail(IDialogContext context, IAwaitable<string> UserEmail)
        {
            string response = await UserEmail;
            email = response; ;

            PromptDialog.Text(
                context: context,
                resume: ResumeGetPhone,
                prompt: "Please share your Mobile Number",
                retry: "Sorry, I didn't understand that. Please try again."
            );
        }
        public virtual async Task ResumeGetPhone(IDialogContext context, IAwaitable<string> mobile)
        {
            string response = await mobile;
            phone = response;

            await context.PostAsync(String.Format("Hello {0} ,Congratulation :) Your  C# Corner Annual Conference 2018 Registrion Successfullly completed with Name = {0} Email = {1} Mobile Number {2} . You will get Confirmation email and SMS", name, email, phone));

            context.Done(this);
        }
    }
}