namespace BotChatService.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using DomainCore;

    using ChatCore;
    using Me.WLF.IDAL;
    using Me.WLF.DALByStatic;

    public static class NinjectWebCommon
    {
        public static StandardKernel kernel = new StandardKernel();

        static NinjectWebCommon()
        {
            kernel.Bind<IUserRepositary>().To<UserRepositaryDALByStatic>();
            kernel.Bind<ITalkSessionRepositry>().To<TalkSessionRepositryByStaticClass>();
            kernel.Bind<IAdminRepositary>().To<AdminRepositaryByDB>();
            kernel.Bind<TalkSession>().ToSelf();
            kernel.Bind<MessageRequestContext>().ToSelf();
        }
    }
}
