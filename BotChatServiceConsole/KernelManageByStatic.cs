using ChatCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

using ChatCore.States;
using ChatCore.States.SearchStates;
using ChatCore.States.UserProfileStates;
using Me.WLF.IDAL;
using Me.WLF.DALByStatic;
using ChatCore.Patterns;
using ChatCore.Patterns.Validators;


namespace ChatCoreConsole
{
    public class KernelManageByStatic : IKernelManager
    {
        private static IKernel _Kernel { get; set; }
        private static object _LockObj = new object();

        public IKernel GetKernel
        {
            get
            {
                if (_Kernel == null)
                {
                    lock (_LockObj)
                    {
                        if (_Kernel == null)
                        {
                            _Kernel = InitKernel();
                        }
                    }
                }
                return _Kernel;
            }
        }

        private IKernel InitKernel()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<NewState>().ToSelf();
            kernel.Bind<NewUserState>().ToSelf();
            kernel.Bind<SearchStartStates>().ToSelf();
            kernel.Bind<WaitLocationState>().ToSelf();
            kernel.Bind<UserProfileState>().ToSelf();
            kernel.Bind<UserProfileWaitNameState>().ToSelf();
            kernel.Bind<JobResultState>().ToSelf();
            kernel.Bind<WaitLanguageState>().ToSelf();

            kernel.Bind<TalkSession>().ToSelf();
            kernel.Bind<IUserRepositary>().To<UserRepositaryDALByStatic>();
            kernel.Bind<ITalkSessionRepositry>().To<TalkSessionRepositryByStaticClass>();
            kernel.Bind<ChineseLastNameValidator>().ToSelf();
            kernel.Bind<IChineseLastNameRepositary>().To<ChineseLastNameRepositaryByStaticClass>();
            kernel.Bind<IStateMessageRepositary>().To<StateMessageRepositaryByStatic>();
            kernel.Bind<IFeedBackRepositary>().To<FeedBackRepositaryByStatic>();

            kernel.Bind<MessageRequestContext>().ToSelf();
            kernel.Bind<IPatternManager>().To<PatternManager>();



            return kernel;

        }
    }
}
