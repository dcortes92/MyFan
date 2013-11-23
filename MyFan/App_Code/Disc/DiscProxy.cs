using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MyFan.App_Data;
using MyFan.App_Code.Negocio;
using MyFan.MyMusicCenterService;
using MyFan.App_Code.Disc;
using System.Data.SqlClient;

namespace MyFan.App_Code.Disc
{
    /// <summary>
    /// Handler of class Disc. This class saves, retrieves and modifies information from the Web Service
    /// </summary>
    public class DiscProxy : DAL
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
        /// Gets from the web service an disc according an disc id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Disc getById(int id)
        {
            mmcService = new MyMusicCenterWSClient();
            js = new JavaScriptSerializer();
            String tempDisc = mmcService.getDiscById(id);
            Disc resultDisc = (Disc)js.Deserialize(tempDisc, typeof(Disc));
            return resultDisc;
        }

        /// <summary>
        /// Gets from the web service for an array of Discs of a given artist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Disc[] getByArtistId(int id)
        {
            mmcService = new MyMusicCenterWSClient();
            js = new JavaScriptSerializer();
            String tempDiscs = mmcService.getDiscsByArtistId(id);
            Disc[] resultDiscs = (Disc[])js.Deserialize(tempDiscs, typeof(Disc[]));
            return resultDiscs;
        }
    }
}