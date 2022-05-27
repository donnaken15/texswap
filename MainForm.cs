using System;
using System.Drawing;
using System.Windows.Forms;
using Nanook.QueenBee.Parser;
using DDS;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace texswap
{
    public partial class MainForm : Form
    {
        public List<Texture> curImgs;
        public List<WPak>    curPaks;
        public Dictionary<uint, string> names = new Dictionary<uint, string>();
        public string curDbg = "";

        public MainForm(string[] args)
        {
            InitializeComponent();
            curImgs = new List<Texture>();
            curPaks = new List<WPak>();
            foreach (string n in File.ReadAllLines("names.txt"))
            {
                names.Add(Convert.ToUInt32(n.Substring(0,8),16), n.Substring(9));
            }
        }

        public string GetCRCName(QbKey key)
        {
            if (key.HasText)
                return key.Text;
            if (names.ContainsKey(key.Crc))
                return names[key.Crc];
            return key.Crc.ToString("X8");
        }

        public string GetCRCName(uint key)
        {
            if (names.ContainsKey(key))
                return names[key];
            return key.ToString("X8");
        }

        void loadFiles(string[] files)
        {
            foreach (string f in files)
            {
                if (curDbg == "")
                {
                    string findDbg = Path.GetDirectoryName(f);
                    //MessageBox.Show(findDbg);
                    if (findDbg.Contains("\\DATA"))
                    {
                        curDbg = findDbg.Substring(0,findDbg.LastIndexOf("\\DATA")+5) + "\\PAK\\dbg.pak.xen";
                        if (!File.Exists(curDbg))
                        {
                            curDbg = "";
                        }
                    }
                }
                if (f.EndsWith(".pak.xen") || f.EndsWith(".pak.wpc"))
                {
                    string pabpart = f.Replace(".pak.", ".pab.");
                    if (!File.Exists(pabpart))
                    {
                        pabpart = f;
                    }
                    //MessageBox.Show(f);
                    //MessageBox.Show(pabpart);
                    //MessageBox.Show(curDbg);
                    WPak curPak = new WPak(f, pabpart, curDbg);
                    curPaks.Add(curPak);
                    TreeNode pakrootitem = new TreeNode(Path.GetFileName(f));
                    pakrootitem.Tag = curPaks.IndexOf(curPak);
                    //new int[] {
                    //curPaks.Count - 1
                    //curPaks.IndexOf(curPak)
                    //};
                    for (int i = 0; i < curPak.texs.Count; i++)
                    {
                        TreeNode texroot = new TreeNode(GetCRCName(curPak.texnames[i]));
                        /*if (curPak.texnames[i].HasText)
                            texroot.Text = curPak.texnames[i].Text;
                        if (names.ContainsKey(curPak.texnames[i].Crc))
                            texroot.Text = names[curPak.texnames[i].Crc];*/
                        texroot.Tag = i;
                        for (int j = 0; j < curPak.texs[i].Count; j++)
                        {
                            Texture curtex = curPak.texs[i][j];
                            TreeNode texitem = new TreeNode(GetCRCName(curtex.meta.key));
                            /*if (curtex.meta.key.HasText)
                                texitem.Text = curtex.meta.key.Text;
                            if (names.ContainsKey(curtex.meta.key.Crc))
                                texitem.Text = names[curtex.meta.key.Crc];*/
                            texitem.ImageIndex = 2;
                            texitem.SelectedImageIndex = texitem.ImageIndex;
                            texitem.Tag = j;
                            texroot.Nodes.Add(texitem);
                        }
                        pakrootitem.Nodes.Add(texroot);
                    }
                    for (int i = 0; i < curPak.textures.Count; i++)
                    {
                        Texture curtex = curPak.textures[i];
                        TreeNode imgitem = new TreeNode(GetCRCName(curtex.meta.key));
                        /*if (curtex.meta.key.HasText)
                            imgitem.Text = curtex.meta.key.Text;
                        if (names.ContainsKey(curtex.meta.key.Crc))
                            imgitem.Text = names[curtex.meta.key.Crc];*/
                        imgitem.ImageIndex = 2;
                        imgitem.SelectedImageIndex = imgitem.ImageIndex;
                        imgitem.Tag = i;
                        pakrootitem.Nodes.Add(imgitem);
                    }
                    pakrootitem.ExpandAll();
                    itemsHolder.Nodes.Add(pakrootitem);
                }
            }
            GC.Collect();
        }

        void loadFileDiag()
        {
            openPak.ShowDialog();
        }

        private void clickLoadToolbtn(object sender, EventArgs e)
        {
            loadFileDiag();
        }

        private void loadFilesFromDiag(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loadFiles(openPak.FileNames);
        }

        private void quit(object sender, FormClosedEventArgs e)
        {
            foreach (var tf in new DirectoryInfo(Path.GetTempPath()).GetFiles("texswaptmp*"))
            {
                try {
                    tf.Delete();
                } catch
                {
                    // why
                }
            }
        }

        private void selectImg(object sender, TreeNodeMouseClickEventArgs e)
        {
            Texture select = new Texture();
            if (e.Node.Level == 0)
                return;
            if (e.Node.Level == 1)
            {
                select = curPaks[(int)e.Node.Parent.Tag].textures[(int)e.Node.Tag];
                curImg.Image = select.image;
                curImg.Tag = new int[]
                {
                    (int)e.Node.Parent.Tag,
                    (int)e.Node.Tag
                };
            }
            if (e.Node.Level == 2)
            {
                select = curPaks[(int)e.Node.Parent.Parent.Tag].
                    texs[(int)e.Node.Parent.Tag][(int)e.Node.Tag];
                curImg.Image = curPaks[(int)e.Node.Parent.Parent.Tag].
                    texs[(int)e.Node.Parent.Tag][(int)e.Node.Tag].image;
            }
            imgpathtxt.Text = GetCRCName(select.meta.key);
            imgwnum.Value = select.meta.width;
            imghnum.Value = select.meta.height;
            unktxt.Text = select.meta.t_unk4.ToString("X4");

            imgPanelCtxt.Items[0].Enabled = true;
            imgPanelCtxt.Items[1].Enabled = true;
            imgpathtxt.Enabled = true;
            imgwnum.Enabled = true;
            imghnum.Enabled = true;
            unktxt.Enabled = true;
            propsApplyBtn.Enabled = true;
        }

        private void xportBtn(object sender, EventArgs e)
        {
            exportDiag.ShowDialog();
        }

        private void mportBtn(object sender, EventArgs e)
        {
            importDiag.ShowDialog();
        }

        private void xportConfirm(object sender, System.ComponentModel.CancelEventArgs e)
        {
            curImg.Image.Save(exportDiag.FileName);
        }
    }

    public class Texture
    {
        public struct TexMeta
        {
            public uint   alwaysXA2802;
            public QbKey  key;
            public ushort width;
            public ushort height;
            public ushort t_unk1;
            public ushort width2;
            public ushort height2;
            public ushort t_unk2;
            public byte   t_unk3;
            public ushort t_unk4;
            public byte   t_unk5;
            public uint   t_unk6;
            public uint   t_off;
            public uint   t_len;
            public uint   t_unk7;
        }
        public TexMeta meta;
        public byte[] rawdata;
        public Image image;
    }

    public class WPak
    {
        static string tmpfile = Path.GetTempPath() + "\\texswaptmp";

        static uint Eswap(uint value)
        {
            return ((value & 0xFF) << 24) |
                    ((value & 0xFF00) << 8) |
                    ((value & 0xFF0000) >> 8) |
                    ((value & 0xFF000000) >> 24);
        }

        static int Eswap(int value)
        {
            return ((value & 0xFF) << 24) |
                    ((value & 0xFF00) << 8) |
                    ((value & 0xFF0000) >> 8) |
                    (int/*???????*/)((value & 0xFF000000) >> 24);
        }

        static ushort Eswap(ushort value)
        {
            /*       WTF    v     */
            return Convert.ToUInt16(((value & 0xFF) << 8) |
                    ((value & 0xFF00) >> 8));
        }

        static int test = 0;
        static string deIMG(byte[] img) // lazy copy
        {
            if (img[0] != 0x0A || img[1] != 0x28 ||
                img[2] != 0x11 || img[3] != 0)
            {
                Console.WriteLine("fail");
                return null;
            }
            uint off = BitConverter.ToUInt32(img, 0x1C);
            uint len = BitConverter.ToUInt32(img, 0x20);
            if (BitConverter.IsLittleEndian)
            {
                off = Eswap(off);
                len = Eswap(len);
            }
            byte[] _out = new byte[len];
            Array.Copy(img, off, _out, 0, len);
            string ext = ".dds";
            byte[] magic = new byte[4];
            Array.Copy(_out, magic, 4);
            byte[][] magics = new byte[4][]
                {
                    new byte[4] { 0x44, 0x44, 0x53, 0x20 },
                    new byte[4] { 0x89, 0x50, 0x4E, 0x47 },
                    new byte[4] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[4] { 0x42, 0x4D, 0x36, 0x16 },
                };
            string[] exts = { ".dds", ".png", ".jpg", ".bmp" };
            for (int i = 0; i < magics.Length; i++)
            {
                if (magic[0] == magics[i][0] &&
                    magic[1] == magics[i][1] &&
                    magic[2] == magics[i][2])
                {
                    ext = exts[i];
                    break;
                }
            }
            // STUPID
            File.WriteAllBytes(tmpfile+"_"+test.ToString()+ext, _out);
            return tmpfile + "_" + (test++).ToString() + ext; // aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        }

        public string stupid(byte[] data)
        {
            string ext = ".dds";
            byte[] magic = new byte[4];
            Array.Copy(data, magic, 4);
            byte[][] magics = new byte[4][]
                {
                    new byte[4] { 0x44, 0x44, 0x53, 0x20 },
                    new byte[4] { 0x89, 0x50, 0x4E, 0x47 },
                    new byte[4] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[4] { 0x42, 0x4D, 0x36, 0x16 },
                };
            string[] exts = { ".dds", ".png", ".jpg", ".bmp" };
            for (int i = 0; i < magics.Length; i++)
            {
                if (magic[0] == magics[i][0] &&
                    magic[1] == magics[i][1] &&
                    magic[2] == magics[i][2])
                {
                    ext = exts[i];
                    break;
                }
            }
            File.WriteAllBytes(tmpfile + "_" + test.ToString() + ext, data);
            return tmpfile + "_" + (test++).ToString() + ext;
        }

        /*public string FindMagic(byte[] data)
        {
            string ext = ".dds";
            byte[] magic = new byte[4];
            Array.Copy(data, magic, 4);
            byte[][] magics = new byte[4][]
                {
                    new byte[4] { 0x44, 0x44, 0x53, 0x20 },
                    new byte[4] { 0x89, 0x50, 0x4E, 0x47 },
                    new byte[4] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[4] { 0x42, 0x4D, 0x36, 0x16 },
                };
            string[] exts = { ".dds", ".png", ".jpg", ".bmp" };
            for (int i = 0; i < magics.Length; i++)
            {
                if (magic[0] == magics[i][0] &&
                    magic[1] == magics[i][1] &&
                    magic[2] == magics[i][2]) // why
                {
                    //Console.WriteLine(magic[0].ToString("X2") + " == " + magics[i][0].ToString("X2"));
                    ext = exts[i];
                    break;
                }
            }
            return ext;
        }*/

        PakFormat pakfmt;
        PakEditor pakedt;

        public string pak, pab;
        public List<Texture> textures;
        public List<List<Texture>> texs;
        public List<QbKey> texnames;

        private static string[] paktypes = {
            ".pak.xen",
            ".pak.wpc",
            //".pak"
        };
        private static string[] pabtypes = {
            ".pab.xen",
            ".pab.wpc",
            //".pab"
        };

        public WPak(string pak, string pab, string dbg)
        {
            PakFormatType type = PakFormatType.PC;
            for (int i = 0; i < paktypes.Length; i++)
            {
                if (pak.EndsWith(paktypes[i]))
                {
                    type = (PakFormatType)(i + 1);
                    break;
                }
            }
            int texid = -1;
            textures = new List<Texture>();
            texs = new List<List<Texture>>();
            texnames = new List<QbKey>();
            pakfmt = new PakFormat(pak, pab, dbg, type);
            pakedt = new PakEditor(pakfmt, false);
            foreach (string f in pakedt.QbFilenames)
            {
                byte[] tmp = pakedt.ExtractFileToBytes(f);
                string newfname;
                if (tmp[0] == 0xFA && tmp[1] == 0xCE &&
                    tmp[2] == 0xCA && tmp[3] == 0xA7)
                {
                    List<Texture> tex = new List<Texture>();
                    Texture texitem;
                    byte count = tmp[7];
                    int entryoffset = Eswap(BitConverter.ToInt32(tmp, 8));
                    for (byte i = 0; i < count; i++)
                    {
                        int curentry = entryoffset + (i * 0x28);
                        texitem = new Texture();
                        texitem.meta = new Texture.TexMeta();
                        texitem.meta.alwaysXA2802 = Eswap(BitConverter.ToUInt32(tmp, curentry));
                        texitem.meta.key    = QbKey.Create(Eswap(BitConverter.ToUInt32(tmp, curentry + 4)));
                        //texitem.meta.rawcrc = Eswap(BitConverter.ToUInt32(tmp, curentry + 4));
                        //MessageBox.Show(texitem.meta.key.Crc.ToString());
                        texitem.meta.width  = Eswap(BitConverter.ToUInt16(tmp, curentry + 8));
                        texitem.meta.height = Eswap(BitConverter.ToUInt16(tmp, curentry + 10));
                        texitem.meta.t_unk1 = Eswap(BitConverter.ToUInt16(tmp, curentry + 12));
                        texitem.meta.width2 = Eswap(BitConverter.ToUInt16(tmp, curentry + 14));
                        texitem.meta.height2 = Eswap(BitConverter.ToUInt16(tmp, curentry + 16));
                        texitem.meta.t_unk2 = Eswap(BitConverter.ToUInt16(tmp, curentry + 0x12));
                        texitem.meta.t_unk3 = tmp[curentry + 0x14];
                        texitem.meta.t_unk4 = Eswap(BitConverter.ToUInt16(tmp, curentry + 0x15));
                        texitem.meta.t_unk5 = tmp[curentry + 0x17];
                        texitem.meta.t_unk6 = Eswap(BitConverter.ToUInt32(tmp, curentry + 0x18));
                        texitem.meta.t_off  = Eswap(BitConverter.ToUInt32(tmp, curentry + 0x1C));
                        texitem.meta.t_len  = Eswap(BitConverter.ToUInt32(tmp, curentry + 0x20));
                        texitem.meta.t_unk7 = Eswap(BitConverter.ToUInt32(tmp, curentry + 0x24));
                        texitem.rawdata = new byte[texitem.meta.t_len];
                        try
                        {
                            Array.Copy(tmp, texitem.meta.t_off, texitem.rawdata, 0, texitem.meta.t_len);
                        }
                        catch
                        {
                            MessageBox.Show(f + ": " + texitem.meta.key.Crc);
                            Application.Exit();
                        }
                        string newfnam2e = stupid(texitem.rawdata);
                        if (newfnam2e.EndsWith(".dds"))
                        {
                            texitem.image = DDSImage.Load(newfnam2e).Images[0];
                        }
                        else
                        {
                            texitem.image = Image.FromFile(newfnam2e);
                        }
                        tex.Add(texitem);
                    }
                    texs.Add(tex);
                    texnames.Add(QbKey.Create(f));
                }
                if (tmp[0] == 0x0A && tmp[1] == 0x28 &&
                    tmp[2] == 0x11 && tmp[3] == 0)
                {
                    //MessageBox.Show("TEST");
                    Texture newimg = new Texture();
                    newimg.meta = new Texture.TexMeta();
                    newimg.meta.alwaysXA2802 = Eswap(BitConverter.ToUInt32(tmp, 0));
                    newimg.meta.key    = QbKey.Create(0x00000000);
                    newimg.meta.width  = Eswap(BitConverter.ToUInt16(tmp, 8));
                    newimg.meta.height = Eswap(BitConverter.ToUInt16(tmp, 0xA));
                    newimg.meta.t_unk1 = Eswap(BitConverter.ToUInt16(tmp, 0xC));
                    newimg.meta.width2 = Eswap(BitConverter.ToUInt16(tmp, 0xE));
                    newimg.meta.height2 = Eswap(BitConverter.ToUInt16(tmp, 0x10));
                    newimg.meta.t_unk2 = Eswap(BitConverter.ToUInt16(tmp, 0x12));
                    newimg.meta.t_unk3 = tmp[0x14];
                    newimg.meta.t_unk4 = Eswap(BitConverter.ToUInt16(tmp, 0x15));
                    newimg.meta.t_unk5 = tmp[0x17];
                    newimg.meta.t_unk6 = Eswap(BitConverter.ToUInt32(tmp, 0x18));
                    newimg.meta.t_off  = Eswap(BitConverter.ToUInt32(tmp, 0x1C));
                    //MessageBox.Show(BitConverter.ToUInt32(tmp, 0x1C).ToString("X8"));
                    //.Show(Eswap(BitConverter.ToUInt32(tmp, 0x1C)).ToString("X8"));
                    newimg.meta.t_len  = Eswap(BitConverter.ToUInt32(tmp, 0x20));
                    newimg.meta.t_unk7 = Eswap(BitConverter.ToUInt32(tmp, 0x24));
                    newimg.rawdata = new byte[newimg.meta.t_len];
                    try {
                        Array.Copy(tmp, newimg.meta.t_off, newimg.rawdata, 0, newimg.meta.t_len);
                    }
                    catch
                    {
                        MessageBox.Show(f);
                        Application.Exit();
                    }
                    newimg.meta.key = QbKey.Create(f);
                    newfname = deIMG(tmp);
                    if (newfname.EndsWith(".dds"))
                    {
                        //DDSImage dds = DDSImage.Load(tmpfile + newext);
                        //if (dds.Images.Length > 0)
                        newimg.image = DDSImage.Load(newfname).Images[0];
                    }
                    else
                    {
                        newimg.image = Image.FromFile(newfname);
                    }
                    //File.Delete(tmpfile + newext);
                    //string ext = FindMagic(newimg.rawdata);
                    textures.Add(newimg);
                }
                //MessageBox.Show(f);
            }
            this.pak = pak;
            this.pab = pab;
        }
    }
}
