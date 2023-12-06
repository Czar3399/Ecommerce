using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Carts.DataTransfers.Requests;
using Ecommerce.Application.Carts.DataTransfers.Responses;
using Ecommerce.Application.Carts.DataTransfers.Responses.Models;
using Ecommerce.Application.Carts.Services.Interfaces;
using Ecommerce.Domain.CartProducts.Entities;
using Ecommerce.Domain.Carts.Entities;
using Ecommerce.Domain.Cupoms.Entities;
using Ecommerce.Domain.Products.Entities;
using Vault.Base.Repositories;

namespace Ecommerce.Application.Carts.Services
{
    public class CartsService(IManipulationRepository manipulationRepository, IQueryRepository queryRepository, IMapper mapper, IUnitOfWork unitOfWork) : ICartsService
    {
        private readonly IManipulationRepository _manipulationRepository = manipulationRepository;
        private readonly IQueryRepository _queryRepository = queryRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public CartResponse Create()
        {
            Cart cart = new();
            cart = _manipulationRepository.Insert(cart);
            return _mapper.Map<CartResponse>(cart);
        }
        public CartResponse Get(long id)
        {
            return _mapper.Map<CartResponse>(_queryRepository.Get<Cart>(id));
        }
        public CartResponse TryManipulateProducts(long id, CartProductRequest request)
        {
            if(request.Quantity == 0)
            {
                throw new Exception("No value to add");
            }

            Cart cart = _queryRepository.GetReference<Cart>(id);
            Product product = _queryRepository.GetReference<Product>(request.ProductId);
            CartProduct cartProduct = _queryRepository.Get<CartProduct>(x => x.Cart.Id == id && x.Product.Id == request.ProductId);

            try
            {
                _unitOfWork.BeginTransaction();
                if(cartProduct == null)
                {
                    cartProduct = new CartProduct()
                    {
                        Cart = cart,
                        Product = product,
                        Quantity = request.Quantity,
                    };

                    _manipulationRepository.Insert(cartProduct);
                }
                else
                {
                    cartProduct.Quantity += request.Quantity;

                    if(cartProduct.Quantity > 0)
                    {
                        _manipulationRepository.Update(cartProduct);
                    }
                    else
                    {
                        _manipulationRepository.Delete(cartProduct);
                    }

                }
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }

            return Get(id);
        }
        public CartResponse AddCoupon(long id, string couponToken)
        {
            Cart cart = _queryRepository.Get<Cart>(id);
            Coupon coupon = _queryRepository.Get<Coupon>(x => x.Token == couponToken);

            if (coupon is null)
            {
                throw new Exception("Invalid coupon");
            }

            try
            {
                _unitOfWork.BeginTransaction();
 
                cart.Coupon = coupon;
                _manipulationRepository.Update(cart);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }

            return _mapper.Map<CartResponse>(cart);
        }

        public CartResponse Submit(long cartId, IEnumerable<CartProductRequest> request)
        {
            return new CartResponse();
        }
    }
}
