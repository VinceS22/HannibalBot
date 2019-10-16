using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using HannibalBot.Services;

namespace HannibalBot.Modules
{
    // Modules must be public and inherit from an IModuleBase
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        // Dependency Injection will fill this value in for us
        public PictureService PictureService { get; set; }

        [Command("ping")]
        [Alias("pong", "hello")]
        public Task PingAsync()
            => ReplyAsync("pong!");

        [Command("cat")]
        public async Task CatAsync()
        {
            // Get a stream containing an image of a cat
            var stream = await PictureService.GetCatPictureAsync();
            // Streams must be seeked to their beginning before being uploaded!
            stream.Seek(0, SeekOrigin.Begin);
            await Context.Channel.SendFileAsync(stream, "cat.png");
        }

        // Get info on a user, or the user who invoked the command if one is not specified
        [Command("userinfo")]
        public async Task UserInfoAsync(IUser user = null)
        {
            user = user ?? Context.User;

            await ReplyAsync(user.ToString());
        }

        // Ban a user
        [Command("ban")]
        [RequireContext(ContextType.Guild)]
        // make sure the user invoking the command can ban
        [RequireUserPermission(GuildPermission.BanMembers)]
        // make sure the bot itself can ban
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task BanUserAsync(IGuildUser user, [Remainder] string reason = null)
        {
            await user.Guild.AddBanAsync(user, reason: reason);
            await ReplyAsync("ok!");
        }

        // [Remainder] takes the rest of the command's arguments as one argument, rather than splitting every space
        [Command("echo")]
        public Task EchoAsync([Remainder] string text)
            // Insert a ZWSP before the text to prevent triggering other bots!
            => ReplyAsync('\u200B' + text);

        // 'params' will parse space-separated elements into a list
        [Command("list")]
        public Task ListAsync(params string[] objects)
            => ReplyAsync("You listed: " + string.Join("; ", objects));

        // Setting a custom ErrorMessage property will help clarify the precondition error
        [Command("guild_only")]
        [RequireContext(ContextType.Guild, ErrorMessage = "Sorry, this command must be ran from within a server, not a DM!")]
        public Task GuildOnlyCommand()
            => ReplyAsync("Nothing to see here!");

        /// <summary>
        /// Takes a list of users and a split amount. Will stage changes to pending approval table
        /// and upon mod/admin approval will apply the split.
        /// EX: !split @Vince @Trey @Val 10k
        /// Response from Hannibal will include an ID for the approvee to use for accepting a split.
        /// </summary>
        /// <returns>The object representing a response from the bot.</returns>
        [Command("split")]
        public Task Split(params string[] objects)
        {
            //TODO: Implement.
            return ReplyAsync("Vince needs to implement me");
        }

        /// <summary>
        /// Approve split if you have sufficient privileges
        /// Ex: !approve @user
        /// </summary>
        /// <param name="objects"></param>
        [Command("approve")]
        public Task Approve(params string[] objects)
        {
            //TODO: Implement.
            return ReplyAsync("Vince needs to implement me");
        }

        /// <summary>
        /// Applies approve method to all available pending splits. Prompts a confirmation with all pending splits before accepting.
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [Command("approveall")]
        public Task ApproveAll(params string[] objects)
        {
            return ReplyAsync("Vince needs to implement me");
        }

        /// <summary>
        /// Denies a posted split
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [Command("deny")]
        public Task Deny(params string[] objects)
        {
            return ReplyAsync("Vince needs to implement me");
        }
        /// <summary>
        /// Checks a given user's splits. TODO: Establish if this requires an elevated privledge.
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [Command("check")]
        public Task Check(params string[] objects)
        {
            return ReplyAsync("Vince Needs to implement me");
        }
        /// <summary>
        /// If user: Clears last split for user
        /// If admin: Clears last split in general
        /// TODO: Establish if this is needed and/or if this is desired.
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [Command("clearlast")]
        public Task ClearLast(params string[] objects)
        {
            return ReplyAsync("Vince needs to implement me");
        }
        /// <summary>
        /// Responds with an ASCII table containing hi-scores.
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [Command("Leaderboard")]
        public Task Leaderboard(params string[] objects)
        {
            return ReplyAsync("Vince needs to implement me");
        }
        /// <summary>
        /// Returns a backup of the DB in JSON format ADMIN ONLY
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [Command("export")]
        public Task Export(params string[] objects)
        {
            return ReplyAsync("Vince needs to implement me");
        }
        /// <summary>
        /// Imports a backup of the DB in JSON format. ADMIN ONLY
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [Command("import")]
        public Task Import(params string[] objects)
        {
            return ReplyAsync("Vince needs to implement me");
        }
        /// <summary>
        /// Straight up adds value to a user.
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [Command("addgp")]
        public Task AddGp(params string[] objects)
        {
            return ReplyAsync("Vince needs to implement me");
        }
        /// <summary>
        /// Removes value from a user.
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [Command("minusgp")]
        public Task MinusGp(params string[] objects)
        {
            return ReplyAsync("Vince needs to implement me");
        }
    }
}
