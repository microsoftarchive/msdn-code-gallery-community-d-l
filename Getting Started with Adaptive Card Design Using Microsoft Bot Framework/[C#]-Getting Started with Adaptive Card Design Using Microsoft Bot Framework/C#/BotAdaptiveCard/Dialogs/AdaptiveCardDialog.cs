using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.IO;
using System.Web;
using System.Collections.Generic;
using AdaptiveCards;

namespace BotAdaptiveCard.Dialogs
{
    [Serializable]
    public class AdaptiveCardDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
            return Task.CompletedTask;
        }
        private readonly IDictionary<string, string> options = new Dictionary<string, string>
{
    { "1", "1. Show Demo Adaptive Card " },
    { "2", "2. Show Demo for Adaptive Card Design with Column" },
    {"3" , "3. Input Adaptive card Design" }

        };
        public async virtual Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var welcomeMessage = context.MakeMessage();
            welcomeMessage.Text = "Welcome to bot Adaptive Card Demo";

            await context.PostAsync(welcomeMessage);

            this.DisplayOptionsAsync(context);
        }

        public void DisplayOptionsAsync(IDialogContext context)
        {
            PromptDialog.Choice<string>(
                context,
                this.SelectedOptionAsync,
                this.options.Keys,
                "What Demo / Sample option would you like to see?",
                "Please select Valid option 1 to 6",
                6,
                PromptStyle.PerLine,
                this.options.Values);
        }
        public async Task SelectedOptionAsync(IDialogContext context, IAwaitable<string> argument)
        {
            var message = await argument;

            var replyMessage = context.MakeMessage();

            Attachment attachment = null;

            switch (message)
            {
                case "1":
                    attachment = CreateAdapativecard();
                    replyMessage.Attachments = new List<Attachment> { attachment };
                    break;
                case "2":
                    attachment = CreateAdapativecardWithColumn();
                    replyMessage.Attachments = new List<Attachment> { attachment };
                    break;
                case "3":
                    replyMessage.Attachments = new List<Attachment> { CreateAdapativecardWithColumn(), CreateAdaptiveCardwithEntry() };
                    break;

            }
           

            await context.PostAsync(replyMessage);

            this.DisplayOptionsAsync(context);
        }
        public Attachment CreateAdapativecard()
        {

            AdaptiveCard card = new AdaptiveCard();

            // Specify speech for the card.
            card.Speak = "Suthahar J is a Technical Lead and C# Corner MVP. He has extensive 10+ years of experience working on different technologies, mostly in Microsoft space. His focus areas are  Xamarin Cross Mobile Development ,UWP, SharePoint, Azure,Windows Mobile , Web , AI and Architecture. He writes about technology at his popular blog http://devenvexe.com";
            // Body content
            card.Body.Add(new Image()
            {
                Url = "https://i1.social.s-msft.com/profile/u/avatar.jpg?displayname=j%20suthahar&size=extralarge&version=88034ca2-9db8-46cd-b767-95d17658931a",
                Size = ImageSize.Small,
                Style = ImageStyle.Person,
                AltText = "Suthahar Profile"

            });

            // Add text to the card.
            card.Body.Add(new TextBlock()
            {
                Text = "Technical Lead and C# Corner MVP",
                Size = TextSize.Large,
                Weight = TextWeight.Bolder
            });

            // Add text to the card.
            card.Body.Add(new TextBlock()
            {
                Text = "jssutahhar@gmail.com"
            });

            // Add text to the card.
            card.Body.Add(new TextBlock()
            {
                Text = "97XXXXXX12"
            });

            // Create the attachment with adapative card.
            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }
        public Attachment CreateAdapativecardWithColumn()
        {
            AdaptiveCard card = new AdaptiveCard()
            {
                Body = new List<CardElement>()
    {
        // Container
        new Container()
        {
            Speak = "<s>Hello!</s><s>Suthahar J is a Technical Lead and C# Corner MVP. He has extensive 10+ years of experience working on different technologies, mostly in Microsoft space. His focus areas are  Xamarin Cross Mobile Development ,UWP, SharePoint, Azure,Windows Mobile , Web , AI and Architecture. He writes about technology at his popular blog http://devenvexe.com</s>",
            Items = new List<CardElement>()
            {
                // first column
                new ColumnSet()
                {
                    Columns = new List<Column>()
                    {
                        new Column()
                        {
                            Size = ColumnSize.Auto,
                            Items = new List<CardElement>()
                            {
                                new Image()
                                {
                                    Url = "https://i1.social.s-msft.com/profile/u/avatar.jpg?displayname=j%20suthahar&size=extralarge&version=88034ca2-9db8-46cd-b767-95d17658931a",
                                    Size = ImageSize.Small,
                                    Style = ImageStyle.Person
                                }
                            }
                        },
                        new Column()
                        {
                            Size = "300",

                            Items = new List<CardElement>()
                            {
                                new TextBlock()
                                {
                                    Text =  "Suthahar Jegatheesan MCA",
                                    Weight = TextWeight.Bolder,
                                    IsSubtle = true
                                },
                                 new TextBlock()
                                {
                                    Text =  "jssuthahar@gmail.com",
                                    Weight = TextWeight.Lighter,
                                    IsSubtle = true
                                },
                                  new TextBlock()
                                {
                                    Text =  "97420XXXX2",
                                    Weight = TextWeight.Lighter,
                                    IsSubtle = true
                                },
                                   new TextBlock()
                                {
                                    Text =  "http://www.devenvexe.com",
                                    Weight = TextWeight.Lighter,
                                    IsSubtle = true
                                }

                            }
                        }
                    }

                },
                // second column
                new ColumnSet()
                {
                     Columns = new List<Column>()
                    {
                          new Column()
                        {
                            Size = ColumnSize.Auto,
                            Separation =SeparationStyle.Strong,
                            Items = new List<CardElement>()
                            {
                                new TextBlock()
                                {
                                    Text = "Suthahar J is a Technical Lead and C# Corner MVP. He has extensive 10+ years of experience working on different technologies, mostly in Microsoft space. His focus areas are  Xamarin Cross Mobile Development ,UWP, SharePoint, Azure,Windows Mobile , Web , AI and Architecture. He writes about technology at his popular blog http://devenvexe.com",
                                    Wrap = true
                                }
                            }
                        }
                    }
                }
            }
        }
     },

            };
            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;

        }
        public Attachment CreateAdaptiveCardwithEntry()
        {
            var card = new AdaptiveCard()
            {
                Body = new List<CardElement>()
    {
            // Hotels Search form
          
            new TextBlock() { Text = "Please Share your detail for contact:" },
            new TextInput()
            {
                Id = "Your Name",
                Speak = "<s>Please Enter Your Name</s>",
                Placeholder = "Please Enter Your Name",
                Style = TextInputStyle.Text
            },
            new TextBlock() { Text = "When your Free" },
            new DateInput()
            {
                Id = "Free",
                Placeholder ="Your free Date"
            },
            new TextBlock() { Text = "Your Experence" },
            new NumberInput()
            {
                Id = "No of Year experence",
                Min = 1,
                Max = 20,
            },
            new TextBlock() { Text = "Email" },
            new TextInput()
            {
                Id = "Email",
                Speak = "<s>Please Enter Your email</s>",
                Placeholder = "Please Enter Your email",
                Style = TextInputStyle.Text
            },
             new TextBlock() { Text = "Phone" },
            new TextInput()
            {
                Id = "Phone",
                Speak = "<s>Please Enter Your phone</s>",
                Placeholder = "Please Enter Your Phone",
                Style = TextInputStyle.Text
            },
    },
                Actions = new List<ActionBase>()
    {
        new SubmitAction()
        {
            Title = "Contact",
            Speak = "<s>Contact</s>",
            
        }
    }
            };
            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }
    }
}