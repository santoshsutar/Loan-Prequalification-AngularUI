using NHibernate;
using NHibernate.Cfg;
using System.Web;

namespace ProEnt.LoanPrequalification.Repositories.NHibernate
{
    public class SessionProvider
    {
        private static ISessionFactory _SessionFactory;
        private static ISession _session;

        private static void Init()
        {
            Configuration  config = new Configuration();
            config.AddAssembly("ProEnt.LoanPrequalification.Repositories.NHibernate");

            log4net.Config.XmlConfigurator.Configure();

            config.Configure();

            _SessionFactory = config.BuildSessionFactory();
        }

        public static ISessionFactory GetSessionFactory()
        {
            if (_SessionFactory == null)
                Init();

            return _SessionFactory;
        }

        public static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items["NHibernateSession"] == null)
                    HttpContext.Current.Items["NHibernateSession"] = GetNewSession();
                return (ISession)HttpContext.Current.Items["NHibernateSession"];
            }
            else
            {
                if (_session == null)
                    _session = GetNewSession();

                return _session;
            }
            
        }
         
    }
}
