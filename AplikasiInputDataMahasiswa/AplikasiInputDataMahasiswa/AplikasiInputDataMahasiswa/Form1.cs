using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputDataMahasiswa
{
    public partial class Form1 : Form
    {
           // deklarasi objek collection
        private List<Mahasiswa> list = new List<Mahasiswa>(); 
            
            // constructor
        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;
            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai Angka", 80, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai Huruf", 70, HorizontalAlignment.Center);

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            // membuat objek mahasiswa
            Mahasiswa mhs = new Mahasiswa();
            // set nilai masing-masing propertynya
            // berdasarkan inputan yang ada di form
            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = int.Parse(txtNilai.Text);
            // tambahkan objek mahasiswa ke dalam collection
            list.Add(mhs);
            var msg = "Data mahasiswa berhasil disimpan.";
            // tampilkan dialog informasi
            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            // reset form input
            //  ResetForm();

            TampilkanData();
        }

        private void TampilkanData()
        {
            // kosongkan data listview
            lvwMahasiswa.Items.Clear();
            // lakukan perulangan untuk menampilkan data mahasiswa ke listview
            foreach (var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                string nilaiHuruf;
                if (mhs.Nilai >= 0 && mhs.Nilai <= 20)
                    nilaiHuruf = "E";
                else if (mhs.Nilai <= 40)
                    nilaiHuruf = "D";
                else if (mhs.Nilai <= 60)
                    nilaiHuruf = "C";
                else if (mhs.Nilai <= 80)
                    nilaiHuruf = "B";
                else
                    nilaiHuruf = "A"; 

                item.SubItems.Add(nilaiHuruf);

                lvwMahasiswa.Items.Add(item);
            }
        }

        private void btnTampilkanData_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

       
      }
    }

