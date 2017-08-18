using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DNA_
{
    public partial class Form1 : Form
    {
        private readonly List<Color> _lstcorlor = new List<Color>();
        readonly ColorDialog _dialog = new ColorDialog();
        public Form1()
        {
            InitializeComponent();
        }
        private readonly ObjectEncode[] _lstEncode = new ObjectEncode[] {
            new ObjectEncode(){Key = 'A',Value= "CGA"},
            new ObjectEncode(){Key = 'B',Value = "CCA"},
            new ObjectEncode(){Key = 'C',Value = "GTT"},
            new ObjectEncode(){Key = 'D',Value = "TTG"},
            new ObjectEncode(){Key = 'E',Value = "GGT"},
            new ObjectEncode(){Key = 'F',Value = "ACT"},
            new ObjectEncode(){Key = 'G',Value = "TTT"},
            new ObjectEncode(){Key = 'H',Value = "CGC"},
            new ObjectEncode(){Key = 'I',Value = "ATG"},
            new ObjectEncode(){Key = 'J',Value = "AGT"},
            new ObjectEncode(){Key = 'K',Value = "AAG"},
            new ObjectEncode(){Key = 'L',Value = "TGC"},
            new ObjectEncode(){Key = 'M',Value = "TCC"},
            new ObjectEncode(){Key = 'N',Value = "TCT"},
            new ObjectEncode(){Key = 'O',Value = "GGC"},
            new ObjectEncode(){Key = 'P',Value = "GGA"},
            new ObjectEncode(){Key = 'Q',Value = "AAC"},
            new ObjectEncode(){Key = 'R',Value = "TCA"},
            new ObjectEncode(){Key = 'S',Value = "ACG"},
            new ObjectEncode(){Key = 'T',Value = "TTC"},
            new ObjectEncode(){Key = 'U',Value = "CTG"},
            new ObjectEncode(){Key = 'V',Value = "CCT"},
            new ObjectEncode(){Key = 'W',Value = "CCG"},
            new ObjectEncode(){Key = 'X',Value = "CTA"},
            new ObjectEncode(){Key = 'Y',Value = "AAA"},
            new ObjectEncode(){Key = 'Z',Value = "AAT"},
            new ObjectEncode(){Key = '0',Value = "TTA"},
            new ObjectEncode(){Key = '1',Value = "ACC"},
            new ObjectEncode(){Key = '2',Value = "TAG"},
            new ObjectEncode(){Key = '3',Value = "GCA"},
            new ObjectEncode(){Key = '4',Value = "GAG"},
            new ObjectEncode(){Key = '5',Value = "AGA"},
            new ObjectEncode(){Key = '6',Value = "GGG"},
            new ObjectEncode(){Key = '7',Value = "ACA"},
            new ObjectEncode(){Key = '8',Value = "AGG"},
            new ObjectEncode(){Key = '9',Value = "GCG"},
            new ObjectEncode(){Key = ' ',Value = "ATA"},
            new ObjectEncode(){Key = ',',Value = "TCG"},
            new ObjectEncode(){Key = '.',Value = "GAT"},
            new ObjectEncode(){Key = ':',Value = "GCT"},
            new ObjectEncode(){Key = ';',Value = "ATT"},
            new ObjectEncode(){Key = '-',Value = "ATC"}
        };

        private readonly CharacterToByte[] _lstByte = new CharacterToByte[]{
            new CharacterToByte(){Key = 'C',value = 0},
            new CharacterToByte(){Key = 'A',value = 1},
            new CharacterToByte(){Key = 'T',value = 2},
            new CharacterToByte(){Key = 'G',value = 3}
        };
        private void btnColor_Click(object sender, EventArgs e)
        {
            _dialog.ShowDialog();
            txtmautin.SelectionLength = txtmautin.Text.Length;
            txtmautin.SelectionColor = _dialog.Color;
        }

        string[] txtMautin_toArray = null;
        string[] txtTindau_toArray = null;
        private  List<String> lst6bitDnae;
        List<Color> _lstcorlor_new;
        Dictionary<int, String> dictionaryColorbit;
        private  List<String> _lst8bitcorlor;
        private void btnProcess_Click(object sender, EventArgs e)
        {
            lst6bitDnae = new List<string>();
            _lstcorlor_new = new List<Color>();
            dictionaryColorbit = new Dictionary<int, String>();
            _lst8bitcorlor = new List<String>();
            var txtMautin = txtmautin.Text;
            var txtTindau = txthidden.Text;
            txtMautin_toArray = txtMautin.Split(' ');
            txtTindau_toArray = txtTindau.ToCharArray().Select(c => c.ToString()).ToArray();
            int sizeOfArray_mautin = txtMautin_toArray.Length;
            int sizeOfArray_tindau = txtTindau.Length;
            if (sizeOfArray_tindau > sizeOfArray_mautin)
            {
                Console.WriteLine("Tin can dau phai co tong so ky tu nho hon hoac bang tong so chu cua mau tin da cho!");
            }
            else
            {

                this.show_origin();
                // start
                for (int i = 0; i < sizeOfArray_tindau; i++)
                {
                    var result = this.get_my(Convert.ToChar(txtTindau_toArray[i]));
                    String my = result[1];
                    String yprimer = result[0];
                    var DANe = this.getDANe(txtTindau_toArray[i], txtMautin_toArray[i], my, yprimer);
                    //Chuyển chuỗi MDNAE thành dạng byte
                    var lstbyteMDNAe = DANe.Select(this.ConvertCharToByte).ToList();
                    var lstByteString = lstbyteMDNAe.Select(p => Convert.ToString(p, 2)).ToList();
                    var dnaeBinaryStr = "";
                    foreach (var item in lstByteString)
                    {
                        if (item.Length == 1)
                        {
                            var tmp = "0" + item;
                            dnaeBinaryStr += tmp;
                        }
                        else
                            dnaeBinaryStr += item;
                    }

                    //Chia nhỏ chuỗi chuỗi DNAe Byte các chuỗi với độ dài bằng 6
                    this.devideDANe_to6bit(dnaeBinaryStr);
                }
                this.conver_color_to_bit();
                this.convert_bitcolor_to_8bit();

                // chia 6bit DNAe thanh 2 bit
                var lstb2itDNAe = new List<string>();
                for (int i = 0; i < lst6bitDnae.Count; i++)
                {
                    var _6bitDNAe = lst6bitDnae[i];
                    for (int j = 0; j < 3; j++)
                    {
                        var bi = _6bitDNAe.Substring(j * 2, 2);
                        lstb2itDNAe.Add(bi);
                    }
                }
                String hex = "";
                // Nhung 2bit DNAe voi moi 8 bit color tuong ung
                for (int i = 0; i < lstb2itDNAe.Count; i++)
                { 

                    String bitcolor_split = lstb2itDNAe[i];
                    String _2bitDNAe = lstb2itDNAe[i];
                    String _8bitcolor = _lst8bitcorlor[i];
                    //Console.WriteLine("_2bitDNAe " + _2bitDNAe);
                    //Console.WriteLine("_8bitcolor= " + _8bitcolor);

                    Console.WriteLine("old bit: " + _8bitcolor);
                    String new_bin = _8bitcolor.Substring(0, _8bitcolor.Length - 2) + _2bitDNAe;
                    _lst8bitcorlor[i] = new_bin;
                    Console.WriteLine("new bit: " + new_bin);
                    if (hex.Length == 6)
                        hex = "";
                    hex += String.Concat(Regex.Matches(new_bin, "....").Cast<Match>().Select(m => Convert.ToInt32(m.Value, 2).ToString("x")));

                    //Console.WriteLine(" index= " + i);
                    //Console.WriteLine("Hex = " + hex);
                    //Color color = ColorTranslator.FromHtml("#" + hex);
                    //Console.WriteLine(color);
                    //_lstcorlor[i] = color;
                }
                for (int i = 0; i < _lst8bitcorlor.Count; i++)
                {
                    var lstmp = new List<int>();
                    String tmp = "";
                    for (var j = 0; j < 3; j++)
                    {
                        tmp += Convert.ToInt32(_lst8bitcorlor[i], 2).ToString("X");
                        if (tmp.Length == 6) {
                            Color color = ColorTranslator.FromHtml("#" + hex);
                            Console.WriteLine(color);
                            _lstcorlor_new.Add(color);
                        }
                    }
                    
                }
                Console.WriteLine(_lstcorlor.Count);
                Console.WriteLine(_lstcorlor_new.Count);
                for (int i = 0; i < _lstcorlor_new.Count; i++) {
                    Console.WriteLine("old = "+_lstcorlor[i]);
                    Console.WriteLine("new = "+ _lstcorlor_new[i]);
                    _lstcorlor[i] = _lstcorlor_new[i];
                }
                // end
                this.show_result_changed();
            }
         }
        private void convert_bitcolor_to_8bit()
        {
            // devide string bit color to type = 8bit color
            for (int i = 0; i < dictionaryColorbit.Count; i++)
            {
                //Console.WriteLine("index = " + i + " value =" + dictionaryColorbit[i]);
                // chia thanh 8 bit mau
                int chunkSizecolor = 8;
                int ColorBinaryLength = dictionaryColorbit[i].Length;
                for (var j = 0; j < ColorBinaryLength; j += chunkSizecolor)
                {
                    if (i + chunkSizecolor < ColorBinaryLength)
                        _lst8bitcorlor.Add(dictionaryColorbit[i].Substring(j, chunkSizecolor));

                }


            }
        }
        private void conver_color_to_bit()
        {
            string bitcolor = "";
            for (int i = 0; i < _lstcorlor.Count; i++)
            {

                string myHexString = String.Format("{0:X2}{1:X2}{2:X2}", _lstcorlor[i].R, _lstcorlor[i].G, _lstcorlor[i].B);
                //Console.WriteLine(_lstcorlor[i].R + " " + _lstcorlor[i].G + " " + _lstcorlor[i].B);
                //Console.WriteLine("myHexString = " + myHexString);
                bitcolor = Convert.ToString(Convert.ToInt32(myHexString, 16), 2);
                if (bitcolor.Equals("0"))
                    bitcolor = "000000000000000000000000";
                dictionaryColorbit.Add(i, bitcolor);
            }
        }
        private void devideDANe_to6bit(String dnaeBinaryStr) {
            int chunkSizeDNAe = 6;
            int dnaeBinaryLength = dnaeBinaryStr.Length;
            //Console.WriteLine("dnaeBinaryStr = " + dnaeBinaryStr + " lenght= "+ dnaeBinaryStr.Length);
            for (var j = 0; j < dnaeBinaryLength; j += chunkSizeDNAe)
            {
                if (j + chunkSizeDNAe > dnaeBinaryLength) chunkSizeDNAe = dnaeBinaryLength - j;
                lst6bitDnae.Add(dnaeBinaryStr.Substring(j, chunkSizeDNAe));
            }
        }
        private List<string> get_my(Char value_hidden)
        {
            var resutl = new List<string>();
            double xzi = 0.21821, wy = 5.1682, zy = 0.7812;

            byte xor = 00;
            Xor(xzi, ref xor);
            
            var lstPrimer = this.ConvertBytetoChar(this.Yprimer(wy, zy));
            var yprimer = lstPrimer.Aggregate("", (current, item) => current + item);

            // value need hide
            var value = DecodeCharacter(value_hidden);
            var lstByteConvert = value.Select(this.ConvertCharToByte).ToList();
            var lstMdna1 = this.AddByte(lstByteConvert, xor);
            var mdna1 = lstMdna1.Aggregate("", (current, item) => current + item);
            var my = "";
            my = yprimer + mdna1;
            resutl.Add(yprimer);
            resutl.Add(my);
            return resutl;
        }
        private void show_origin()
        {
            // lay mau cua tung ky tu trong mau tin
            for (int i = 0; i < txtmautin.Text.Trim().Length; i++)
            {
                lstlblCurrent.Text = "";
                txtmautin.Select(i, 1);
                lstlblCurrent.Items.Add(txtmautin.SelectionColor.R + " " + txtmautin.SelectionColor.G + " " + txtmautin.SelectionColor.B);
                _lstcorlor.Add(txtmautin.SelectionColor);
            }

        }
        private void show_result_changed()
        {
            lstlblAfter.Items.Clear();
            txtResult.Text = txtmautin.Text;
            for (int i = 0; i < _lstcorlor.Count; i++)
            {
                //int index = txtSimple.Text.IndexOf(txtMautin_toArray[i]);
                Console.WriteLine("index = "+ i+ _lstcorlor[i]);
                lstlblAfter.Items.Add(_lstcorlor[i].R + " " + _lstcorlor[i].G + " " + _lstcorlor[i].B);
                txtResult.Select(i, 1);
                txtResult.SelectionColor = _lstcorlor[i];
            }
        }

        private String getDANe(String tindau, String mautin, String my, String yprimer)
        {
            int loop_yprimer = mautin.Length - 2;
            var DANe = "";
            if (loop_yprimer == 1)
                DANe = yprimer + my;
            else if (loop_yprimer == 2)
                DANe = yprimer + my + yprimer;
            else if (loop_yprimer == 3)
                DANe = yprimer + yprimer + my + yprimer;
            else if (loop_yprimer == 4)
                DANe = yprimer + yprimer + my + yprimer + yprimer;
            return DANe;
        }

        private IEnumerable<byte> Yprimer(double wi, double zi)
        {
            var lst = new List<byte>();
            for (double i = 1, ztest = zi; i <= 3; i++)
            {
                var sub = Math.Acos(ztest);
                ztest = Math.Cos(i * sub);
                if ((ztest > -1) && (ztest < -0.5))
                    lst.Add(3);  // G
                else if ((ztest > -0.5) && (ztest <= 0))
                    lst.Add(2); // T
                else if ((ztest > 0) && (ztest <= 0.5))
                    lst.Add(1); // A
                else if ((ztest > 0.5) && (ztest < 1))
                    lst.Add(0); // C
            }
            return lst;
        }
        private static void Xor(double zi, ref byte xi)
        {
            if ((zi > -1) && (zi <= -0.5))
                xi = 0;
            else if ((zi > -0.5) && (zi <= 0))
                xi = 1;
            else if ((zi > 0) && (zi <= 0.5))
                xi = 2;
            else if ((zi > 0.5) && (zi < 1))
                xi = 3;
        }

        private string DecodeCharacter(char a)
        {
            var firstOrDefault = _lstEncode.FirstOrDefault(p => p.Key == a);
            return firstOrDefault != null ? firstOrDefault.Value : "";
        }
        private IEnumerable<char> ConvertBytetoChar(IEnumerable<byte> lst)
        {
            var enumerable = lst as IList<byte> ?? lst.ToList();
            return enumerable.Any()
                ? enumerable.Select(p => _lstByte.Where(k => k.value.Equals(p)).Select(z => z.Key).FirstOrDefault())
                    .ToList()
                : new List<char>();
        }
        private byte ConvertCharToByte(char a)
        {
            var ret = _lstByte.FirstOrDefault(p => p.Key == a);
            return (byte)ret.value;
            //return (byte)ret?.value ?? new byte();
        }
        private IEnumerable<char> AddByte(IEnumerable<byte> lst, byte test)
        {
            //List<byte> lsttest = new List<byte>();
            var lsttest = lst.Select(p => (byte)((byte)(p + test) & 3)).ToList();
            return this.ConvertBytetoChar(lsttest.Select(p => byte.Parse(p + "")).ToList());
        }

        private void btnClearAfter_Click(object sender, EventArgs e)
        {
            lstlblAfter.Items.Clear();
        }
    }
}
