//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApplication2.Commands.Request;
//using WebApplication2.Commands.Response;
//using WebApplication2.Interfaces;
//using WebApplication2.Model;

//namespace WebApplication2.Handlers
//{
//    public class RequestProductHandler : IRequestProductHandler
//    {
//        private readonly IProductRepository _repository;

//        public RequestProductHandler(IProductRepository repository)
//        {
//            _repository = repository;
//        }

//        public void HandlerCreate(Commands.Request.GetAllProductsResponse command)
//        {
//            var product = new Product(command.Title, command.Price );
//            _repository.Create(product);

//        }

//        public void HandlerDelete(int id)
//        {
//            _repository.Delete(id);
//        }

//        public void HandlerUpdate(Commands.Request.GetAllProductsResponse command)
//        {
//            var product = new Product(command.Id, command.Title, command.Price);
//            _repository.Update(product);
//        }
//    }
//}
