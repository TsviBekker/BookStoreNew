using Autofac;
using Autofac.Features.ResolveAnything;
using BookStore.Client.ViewModel.ManagerViewModel;
using BookStore.Service.Context;
using BookStore.Service.Repositories.BookRepo;
using BookStore.Service.Repositories.JournalRepo;
using BookStore.Service.Services.Cart;
using BookStore.Service.Services.Cart.Checkout;
using BookStore.Service.Services.Cart.Discount;
using System.Windows;

namespace BookStore.Client
{
    public partial class App : Application
    {
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();

            //allow the Autofac container resolve unknown types
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            //DbContext
            builder.RegisterType<BookStoreContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<BookStoreContextFactory>().AsSelf().SingleInstance();

            //Repositories
            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JournalRepository>().As<IJournalRepository>().InstancePerLifetimeScope();

            //Other Services
            builder.RegisterType<DiscountService>().As<IDiscountService>().InstancePerLifetimeScope();
            builder.RegisterType<Cart>().As<ICart>().SingleInstance();
            builder.RegisterType<CheckoutService>().As<ICheckoutService>().InstancePerLifetimeScope();

            //ViewModels
            builder.RegisterType<AddBooksViewModel>().AsSelf().InstancePerLifetimeScope();

            IContainer container = builder.Build();
            ////get a MainViewModel instance
            //MainViewModel mainViewModel = container.Resolve<MainViewModel>();

            DISource.Resolver = (type) => container.Resolve(type);
        }
    }
}
