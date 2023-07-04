using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using ProductViewModel = OnlineShopWebApp.Models.ProductViewModel;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {

                productViewModels.Add(ToProductViewModel(product));
            }
            return productViewModels;
        }

        public static ProductViewModel ToProductViewModel(Product product)
        {

            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagesPaths = product.Images.Select(x => x.Url).ToArray(),
                NameCategory = product.ProductCategories
            };

        }





        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartViewModels(cart.Items)
            };
        }


        public static List<CartItemViewModel> ToCartViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }


        public static OrderViewModel ToOrderViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CreateDateTime = order.CreateDateTime,
                Status = (OrderStatusViewModel)(int)order.Status,
                User = ToUserDeliveryInfoViewModel(order.User),
                Items = ToCartViewModels(order.Items)
            };
        }

        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(UserDeliveryInfo userDeliveryInfo)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = userDeliveryInfo.Name,
                Address = userDeliveryInfo.Adress,
                Phone = userDeliveryInfo.Phone
            };
        }


        public static UserDeliveryInfo ToUser(this UserDeliveryInfoViewModel user)
        {
            return new UserDeliveryInfo
            {
                Name = user.Name,
                Adress = user.Address,
                Phone = user.Phone

            };
        }


        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Name = user.UserName,
                Phone = user.PhoneNumber,
                Email = user.Email

            };
        }




        public static Product ToProduct(this AddProductViewModel addProductViewModel, List<string> imagesPaths, ProductCategory category)
        {
            return new Product
            {
                Name = addProductViewModel.Name,
                Cost = addProductViewModel.Cost,
                Description = addProductViewModel.Description,
                Images = ToImages(imagesPaths),
                ProductCategories = category
            };
        }

        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(x => new Image { Url = x }).ToList();
        }


        public static UserViewModel ToUserViewModelEdit(User user)
        {
            var userV = new UserViewModel
            {
                Id = user.Id,
                Name = user.UserName,
                Phone = user.PhoneNumber,
                Email = user.Email,

            };
            return userV;
        }


        public static User ToUserEdit(UserViewModel userAccount)
        {
            var userDb = new User
            {
                Id = userAccount.Id,

                UserName = userAccount.Name,

                PhoneNumber = userAccount.Phone,

                Email = userAccount.Email

            };
            return userDb;

        }

        public static EditProductViewModel ToEditProductViewModel(this Product product)
        {
            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImagesPaths = product.Images.ToPaths()
            };
        }

        public static List<string> ToPaths(this List<Image> paths)
        {
            return paths.Select(x => x.Url).ToList();
        }

        public static Product ToProduct(this EditProductViewModel editProduct)
        {
            return new Product
            {
                Id = editProduct.Id,
                Name = editProduct.Name,
                Description = editProduct.Description,
                Cost = editProduct.Cost,
                Images = editProduct.ImagesPaths.ToImages()
            };
        }



        public static List<CategoryViewModel> ToProductCategoryViewModels(this List<ProductCategory> productCategories)
        {
            var categoriesViewModels = new List<CategoryViewModel>();
            foreach (var item in productCategories)
            {
                categoriesViewModels.Add(new CategoryViewModel
                {
                    Id = item.Id,
                    CategoryName = item.Name
                });
            }
            return categoriesViewModels;
        }



        public static List<CategoryViewModel> ToProductVCategoryViewModels(List<ProductCategory> categories)
        {
            var productsViewModels = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                productsViewModels.Add(new CategoryViewModel
                {
                    Id = item.Id,
                    CategoryName = item.Name
                });
            }
            return productsViewModels;
        }



        /*
         public static List<CartItemViewModel> ToCartViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }

         */
    }
}
