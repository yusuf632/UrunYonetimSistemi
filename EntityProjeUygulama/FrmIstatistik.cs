using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            LblToplamKategoriSayisi.Text = db.TBLKATEGORI.Count().ToString();
            LblToplamUrunSayisi.Text = db.TBLURUN.Count().ToString();
            LblAktifMusteriSayısı.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            LblPasifMusteriSayisi.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            LblToplamStok.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            LblKasadakiTutar.Text = db.TBLURUN.Sum(x => x.FIYAT).ToString() + " TL";
            LblEnYuksekFiyatliUrun.Text = (from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            LblEnDusukFiyatliUrun.Text = (from x in db.TBLURUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();
            LblBeyazEsyaSayisi.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            LblToplamBuzdolabiSayisi.Text = db.TBLURUN.Count(x => x.URUNAD == "Buzdolabı").ToString();
            LblSehirSayisi.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            LblEnFazlaUrunluMarka.Text = db.MARKAGETIR().FirstOrDefault();
        }
    }
}
