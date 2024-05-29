using NewsAPI.APIModel.Category;
using NewsAPI.APIModel.Comments;
using NewsAPI.APIModel.News;

namespace NewsAPI.APIModel;

public class Profile : AutoMapper.Profile
{
    public Profile()
    {
        #region Category

        CreateMap<CreateCategoryModel, Entities.Category>();
        CreateMap<Entities.Category, GetByIdCategoryModel>();
        CreateMap<Entities.Category, GetCategoryModel>();
        CreateMap<UpdateCategoryModel, Entities.Category>();

        #endregion

        #region Comments

        CreateMap<CreateCommentModel, Entities.Comments>();
        CreateMap<Entities.Comments, GetByIdCommentModel>();
        CreateMap<Entities.Comments, GetCommentModel>();
        CreateMap<UpdateCommentModel, Entities.Comments>();

        #endregion

        #region News

        CreateMap<CreateNewsModel, Entities.News>();
        CreateMap<Entities.News, GetByIdNewsModel>();
        CreateMap<Entities.News, GetNewsModel>();
        CreateMap<UpdateNewsModel, Entities.News>();

        #endregion
    }
}