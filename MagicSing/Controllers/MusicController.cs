using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagicSing.Models;
using MagicSing.Models.ViewModels;
using System.Diagnostics;

namespace MagicSing.Controllers
{
    public class MusicController : Controller
    {
        private MusicCMSContext db = new MusicCMSContext();

        // GET: Music
        public ActionResult List(string search)
        { 
            return View(db.Musics.Where(x => x.Title.Contains(search) || search == null).ToList());
        }

        public ActionResult Play(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }

        public ActionResult New()
        {           
            PlaylistItem playlistItem = new PlaylistItem();
            playlistItem.playlists = db.Playlists.ToList();

            return View(playlistItem);
        }
        [HttpPost]
        public ActionResult Create(int Playlist_New, string Title_New, string Artist_New, string Album_New, DateTime Year_New, string URL_New)
        {
            string query = "INSERT INTO Musics (PlaylistID, Title, Artist, Album, Year, URL) values (@playlist, @title, @artist, @album, @year, @url)";
            SqlParameter[] myparams = new SqlParameter[6];
            myparams[0] = new SqlParameter("@playlist", Playlist_New);
            myparams[1] = new SqlParameter("@title", Title_New);
            myparams[2] = new SqlParameter("@artist", Artist_New);
            myparams[3] = new SqlParameter("@album", Album_New);
            myparams[4] = new SqlParameter("@year", Year_New);
            myparams[5] = new SqlParameter("@url", URL_New);
       
            db.Database.ExecuteSqlCommand(query, myparams);
        
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusicID, Title, PlaylistID, Artist, Album, Year, URL")] Music music)
        {
            if (ModelState.IsValid)
            {
                db.Entry(music).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(music);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Music music = db.Musics.Find(id);
            db.Musics.Remove(music);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}