using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using MyFan.App_Code.Negocio;
using MyFan.App_Code.Noticia;
using MyFan.MyMusicCenterService;

namespace MyFan.App_Code.Noticia
{
    /// <summary>
    /// Handler of class News. This class saves, retrieves and modifies information from the Web Service
    /// </summary>
    public class NewsProxy : DAL
    {
        /// <summary>
        /// Reference to the web service of my music.
        /// </summary>
        private MyMusicCenterWSClient mmcService;

        /// <summary>
        /// Serializer that allows parsing a JSon string to an object.
        /// </summary>
        private JavaScriptSerializer js;

        /// <summary>
        /// Asks the web service a news according an news id.
        /// </summary>
        /// <param name="news_id">The id of the news to be loaded.</param>
        /// <returns>News object with the info of the news.</returns>
        public News getById(int news_id)
        {
            mmcService = new MyMusicCenterWSClient();
            js = new JavaScriptSerializer();
            String tempArtist = mmcService.getNewsById(news_id);
            News resultArtist = (News)js.Deserialize(tempArtist, typeof(News));
            return resultArtist;
        }

        /// <summary>
        /// Ask the web service for an array of news of a specific artist id
        /// </summary>
        /// <param name="artist_id">Id of the artist.</param>
        /// <returns>Array of news of the artist.</returns>
        public News[] getByArtistId(int artist_id)
        {
            mmcService = new MyMusicCenterWSClient();
            js = new JavaScriptSerializer();
            String tempNews = mmcService.getNewsByArtistId(artist_id);
            News[] resultNews = (News[])js.Deserialize(tempNews, typeof(News[]));
            return resultNews;
        }
    }
}