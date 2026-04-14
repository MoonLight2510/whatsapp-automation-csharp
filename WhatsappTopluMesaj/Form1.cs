using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
namespace WhatsappTopluMesaj
{

    public partial class Form1 : Form
    {
        string excelDosyaYolu = "";
        IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
            KombolariDoldur();
            GridiHazirla();

        }
        private void GridiExceleKaydet()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(excelDosyaYolu))
                {
                    MessageBox.Show("Önce Excel Yükle ile Excel dosyasýný seç.");
                    return;
                }
                Excel.Application excelUygulamasi = new Excel.Application();
                Excel.Workbook kitap = excelUygulamasi.Workbooks.Open(excelDosyaYolu);
                Excel.Worksheet sayfa = (Excel.Worksheet)kitap.Sheets[1];

                sayfa.Cells[1, 1] = "Kiþi";
                sayfa.Cells[1, 2] = "A. Kodu";
                sayfa.Cells[1, 3] = "Numara";
                sayfa.Cells[1, 4] = "Ýþlem Türü";
                sayfa.Cells[1, 5] = "Mesaj";
                sayfa.Cells[1, 6] = "Dosya Yolu";

                int excelSatir = 2;

                for (int i = 0; i < gridexcel.Rows.Count; i++)
                {
                    if (gridexcel.Rows[i].IsNewRow)
                        continue;

                    string kisi = gridexcel.Rows[i].Cells[0].Value?.ToString() ?? "";
                    string aKodu = gridexcel.Rows[i].Cells[1].Value?.ToString() ?? "";
                    string numara = gridexcel.Rows[i].Cells[2].Value?.ToString() ?? "";
                    string islemTuru = gridexcel.Rows[i].Cells[3].Value?.ToString() ?? "";
                    string mesaj = gridexcel.Rows[i].Cells[4].Value?.ToString() ?? "";
                    string dosyaYolu = gridexcel.Rows[i].Cells[5].Value?.ToString() ?? "";

                    sayfa.Cells[excelSatir, 1] = kisi;
                    sayfa.Cells[excelSatir, 2] = aKodu;
                    sayfa.Cells[excelSatir, 3] = numara;
                    sayfa.Cells[excelSatir, 4] = islemTuru;
                    sayfa.Cells[excelSatir, 5] = mesaj;
                    sayfa.Cells[excelSatir, 6] = dosyaYolu;

                    excelSatir++;
                }

                kitap.Save();
                kitap.Close(false);
                excelUygulamasi.Quit();

                MessageBox.Show("Grid verileri Excel'e kaydedildi.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Excel'e kaydederken hata oluþtu: " + hata.Message);
            }
        }

        private string HucreMetni(Excel.Range hucre)
        {
            if (hucre == null || hucre.Value2 == null)
                return "";

            return Convert.ToString(hucre.Value2)?.Trim() ?? "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void GridiHazirla()
        {
            gridexcel.DataSource = null;
            gridexcel.Rows.Clear();
            gridexcel.Columns.Clear();

            gridexcel.Enabled = true;
            gridexcel.Visible = true;
            gridexcel.BackgroundColor = Color.White;
            gridexcel.AutoGenerateColumns = false;
            gridexcel.AllowUserToAddRows = true;

            gridexcel.Columns.Add("colKisi", "Kiþi");
            gridexcel.Columns.Add("colAKodu", "A. Kodu");
            gridexcel.Columns.Add("colNumara", "Numara");
            gridexcel.Columns.Add("colIslemTuru", "Ýþlem Türü");
            gridexcel.Columns.Add("colMesaj", "Mesaj");
            gridexcel.Columns.Add("colDosyaYolu", "Dosya Yolu");

            gridexcel.Columns["colKisi"].Width = 120;
            gridexcel.Columns["colAKodu"].Width = 100;
            gridexcel.Columns["colNumara"].Width = 120;
            gridexcel.Columns["colIslemTuru"].Width = 120;
            gridexcel.Columns["colMesaj"].Width = 300;
            gridexcel.Columns["colDosyaYolu"].Width = 220;
        }
        private void KombolariDoldur()
        {
            combomin.Items.Add("1");
            combomin.Items.Add("2");
            combomin.Items.Add("3");

            combomaks.Items.Add("10");
            combomaks.Items.Add("20");
            combomaks.Items.Add("30");

            comboefazla.Items.Add("50");
            comboefazla.Items.Add("100");
            comboefazla.Items.Add("200");

            combomin.SelectedIndex = 0;
            combomaks.SelectedIndex = 0;
            comboefazla.SelectedIndex = 0;
        }

        private void gridexcel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnExcelYukle_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog dosyaSec = new OpenFileDialog();
                dosyaSec.Filter = "Excel Dosyalarý|*.xlsx;*.xls";

                if (dosyaSec.ShowDialog() == DialogResult.OK)
                {
                    excelDosyaYolu = dosyaSec.FileName;
                    string dosyaYolu = dosyaSec.FileName;

                    Excel.Application excelUygulamasi = new Excel.Application();
                    Excel.Workbook kitap = excelUygulamasi.Workbooks.Open(dosyaYolu);
                    Excel.Worksheet sayfa = (Excel.Worksheet)kitap.Sheets[1];
                    Excel.Range kullanilanAlan = sayfa.UsedRange;

                    int satirSayisi = kullanilanAlan.Rows.Count;

                    gridexcel.Rows.Clear();

                    for (int i = 2; i <= satirSayisi; i++)
                    {
                        string kisi = HucreMetni(kullanilanAlan.Cells[i, 1] as Excel.Range);
                        string aKodu = HucreMetni(kullanilanAlan.Cells[i, 2] as Excel.Range);
                        string numara = HucreMetni(kullanilanAlan.Cells[i, 3] as Excel.Range);
                        string islemTuru = HucreMetni(kullanilanAlan.Cells[i, 4] as Excel.Range);
                        string mesaj = HucreMetni(kullanilanAlan.Cells[i, 5] as Excel.Range);
                        string dosya = HucreMetni(kullanilanAlan.Cells[i, 6] as Excel.Range);

                        if (!string.IsNullOrWhiteSpace(kisi) ||
                            !string.IsNullOrWhiteSpace(aKodu) ||
                            !string.IsNullOrWhiteSpace(numara) ||
                            !string.IsNullOrWhiteSpace(islemTuru) ||
                            !string.IsNullOrWhiteSpace(mesaj) ||
                            !string.IsNullOrWhiteSpace(dosya))
                        {
                            gridexcel.Rows.Add(kisi, aKodu, numara, islemTuru, mesaj, dosya);
                        }
                    }

                    kitap.Close(false);
                    excelUygulamasi.Quit();

                    MessageBox.Show("Excel verileri baþarýyla yüklendi.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata oluþtu: " + hata.Message);
            }

        }

        private async void btngonder_Click(object sender, EventArgs e)
        {
            try
            {
                GridiExceleKaydet();

                ChromeOptions ayar = new ChromeOptions();
                ayar.AddArgument("--start-maximized");

                driver = new ChromeDriver(ayar);
                driver.Navigate().GoToUrl("https://web.whatsapp.com/");

    
                for (int i = 0; i < gridexcel.Rows.Count; i++)
                {
                    if (gridexcel.Rows[i].IsNewRow)
                        continue;

                    string kisi = gridexcel.Rows[i].Cells[0].Value?.ToString()?.Trim() ?? "";
                    string aKodu = gridexcel.Rows[i].Cells[1].Value?.ToString()?.Trim() ?? "";
                    string numara = gridexcel.Rows[i].Cells[2].Value?.ToString()?.Trim() ?? "";
                    string mesaj = gridexcel.Rows[i].Cells[4].Value?.ToString()?.Trim() ?? "";
                    string dosyaYolu = gridexcel.Rows[i].Cells[5].Value?.ToString()?.Trim() ?? "";

                    string tamNumara = aKodu + numara;

                    if (string.IsNullOrWhiteSpace(tamNumara))
                        continue;

                    try
                    {
                        string url = $"https://web.whatsapp.com/send?phone={tamNumara}&text={Uri.EscapeDataString(mesaj)}";
                        driver.Navigate().GoToUrl(url);

                        await Task.Delay(8000);

                        IWebElement mesajKutusu = null;

                        for (int deneme = 0; deneme < 15; deneme++)
                        {
                            await Task.Delay(1000);

                            var kutular = driver.FindElements(By.XPath("//footer//div[@contenteditable='true']"));
                            if (kutular.Count > 0)
                            {
                                mesajKutusu = kutular[0];
                                break;
                            }
                        }

                        if (mesajKutusu == null)
                        {
                            MessageBox.Show($"Sohbet açýlamadý: {kisi} - {tamNumara}");
                            continue;
                        }

                        // 1) Mesaj gönder
                        if (!string.IsNullOrWhiteSpace(mesaj))
                        {
                            try
                            {
                                mesajKutusu.Click();
                                await Task.Delay(1000);
                                mesajKutusu.SendKeys(OpenQA.Selenium.Keys.Enter);
                                await Task.Delay(2500);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Mesaj gönderilemedi: {kisi} - {tamNumara}\nHata: {ex.Message}");
                                continue;
                            }
                        }

                        // 2) Dosya gönder
                        if (!string.IsNullOrWhiteSpace(dosyaYolu))
                        {
                            try
                            {
                                if (!System.IO.File.Exists(dosyaYolu))
                                {
                                    MessageBox.Show($"Dosya bulunamadý: {dosyaYolu}");
                                    continue;
                                }

                                IWebElement ekleButonu = null;

                                // 1
                                var butonlar1 = driver.FindElements(By.XPath("//span[@data-icon='clip']/ancestor::*[@role='button'][1]"));
                                if (butonlar1.Count > 0)
                                    ekleButonu = butonlar1[0];

                                // 2
                                if (ekleButonu == null)
                                {
                                    var butonlar2 = driver.FindElements(By.XPath("//*[@title='Attach' or @title='Ekle']"));
                                    if (butonlar2.Count > 0)
                                        ekleButonu = butonlar2[0];
                                }

                                // 3
                                if (ekleButonu == null)
                                {
                                    var butonlar3 = driver.FindElements(By.XPath("//*[@aria-label='Attach' or @aria-label='Ekle']"));
                                    if (butonlar3.Count > 0)
                                        ekleButonu = butonlar3[0];
                                }

                                // 4
                                if (ekleButonu == null)
                                {
                                    var butonlar4 = driver.FindElements(By.XPath("//div[@role='button' and (@title='Attach' or @title='Ekle' or @aria-label='Attach' or @aria-label='Ekle')]"));
                                    if (butonlar4.Count > 0)
                                        ekleButonu = butonlar4[0];
                                }

                                // 5
                                if (ekleButonu == null)
                                {
                                    var butonlar5 = driver.FindElements(By.CssSelector("span[data-icon='clip']"));
                                    if (butonlar5.Count > 0)
                                        ekleButonu = butonlar5[0];
                                }

                                if (ekleButonu == null)
                                {
                                    MessageBox.Show($"Ataç/Ekle butonu bulunamadý: {kisi}");
                                    continue;
                                }

                                ekleButonu.Click();
                                await Task.Delay(2500);

                                var dosyaInputlari = driver.FindElements(By.CssSelector("input[type='file']"));
                                if (dosyaInputlari.Count == 0)
                                {
                                    MessageBox.Show($"Dosya seçme alaný bulunamadý: {kisi}");
                                    continue;
                                }

                                dosyaInputlari[dosyaInputlari.Count - 1].SendKeys(dosyaYolu);
                                await Task.Delay(5000);

                                var gonderButonlari = driver.FindElements(By.XPath(
                                    "//*[@aria-label='Send' or @aria-label='Gönder' or @title='Send' or @title='Gönder'] | //span[@data-icon='send']/ancestor::*[@role='button'][1]"
                                ));

                                if (gonderButonlari.Count == 0)
                                {
                                    MessageBox.Show($"Dosya gönder butonu bulunamadý: {kisi}");
                                    continue;
                                }

                                gonderButonlari[gonderButonlari.Count - 1].Click();
                                await Task.Delay(5000);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Dosya gönderilemedi: {kisi} - {dosyaYolu}\nHata: {ex.Message}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Satýr iþlenirken hata oluþtu.\nKiþi: {kisi}\nNumara: {tamNumara}\nHata: {ex.Message}");
                    }
                }

                MessageBox.Show("Tüm iþlemler tamamlandý.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata oluþtu: " + hata.Message);
            }
        }

        private void gridexcel_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridexcel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // 5. sütun = Dosya Yolu
            if (e.ColumnIndex == 5)
            {
                OpenFileDialog dosyaSec = new OpenFileDialog();
                dosyaSec.Title = "Dosya Seç";

                if (dosyaSec.ShowDialog() == DialogResult.OK)
                {
                    gridexcel.Rows[e.RowIndex].Cells[5].Value = dosyaSec.FileName;
                }
            }
        }
    }

}