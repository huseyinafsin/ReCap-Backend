//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Autofac;
//using Autofac.Core;
//using Autofac.Core.Activators.Reflection;
//using Autofac.Extras.DynamicProxy;
//using AutoMapper;
//using Business.Abstract;
//using Business.Concrete;
//using Business.Mapping;
//using Castle.DynamicProxy;
//using Core.DataAccess;
//using Core.DataAccess.EntityFramework;
//using Core.Entities;
//using Core.Services;
//using Core.Utilities.Interceptors;
//using Core.Utilities.Security.JWT;
//using DataAccess.Abstract;
//using DataAccess.Concrete;
//using DataAccess.Concrete.EntityFramework;
//using Microsoft.EntityFrameworkCore;

//namespace Business.DependencyResolvers.Autofac
//{
//    public class AutofacBusinessModule :Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
           

//            //builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
//            //builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
                        
//            //builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
//            //builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
                        
//            //builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
//            //builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
                        
//            //builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
//            //builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
                        
//            //builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
//            //builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
                                    
//            //builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
//            //builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();    
            
//            //builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
//            //builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance(); 
            
//            //builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
//            //builder.RegisterType<JwtHelper>().As<ITokenHelper>(); 
            
//            //builder.RegisterType<CreditCardManager>().As<ICreditCardService>().SingleInstance();
//            //builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>();     
            
//            //builder.RegisterType<PaymentManager>().As<IPaymentService>().SingleInstance();
//            //builder.RegisterType<EfPaymentDal>().As<IPaymentDal>();   

//            //builder.RegisterType<MailSubscribeManager>().As<IMailSubscribeService>().SingleInstance();
//            //builder.RegisterType<EfMailSubscribeDal>().As<IMailSubscriberDal>();

//            //builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerDependency();
//            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();


//            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

//            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
//                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
//                {
//                    Selector = new AspectInterceptorSelector()
//                }).SingleInstance();

//        }
//    }
//}
