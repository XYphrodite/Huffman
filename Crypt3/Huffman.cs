namespace crypt3
{
    public class Huffman
    {
        public Node? tNode;
        public string Compress(string fileToCompress, string pathToWrite)
        {
            byte[] data = File.ReadAllBytes(fileToCompress);
            byte[] arch = CompressBytes(data);
            File.WriteAllBytes(pathToWrite, arch);
            string toReturn = string.Empty;
            foreach (byte b in arch)
            {
                toReturn += b.ToString();
            }
            return toReturn;
        }

        private byte[] CompressBytes(byte[] data)
        {
            int[] freqs = CalculateFrequency(data);
            byte[] head = CreateHeader(data.Length, freqs);
            Node root = CreateHuffmanTree(freqs);
            tNode = root;
            string[] codes = CreateHuffmanCode(root);
            byte[] bits = Compress(data, codes);
            return head.Concat(bits).ToArray();
        }

        private byte[] CreateHeader(int dataLength, int[] freqs)
        {
            List<byte> head = new List<byte>();
            head.Add((byte)(dataLength & 255));
            head.Add((byte)(dataLength >> 8 & 255));
            head.Add((byte)(dataLength >> 16 & 255));
            head.Add((byte)(dataLength >> 24 & 255));
            for (int j = 0; j < 256; j++)
                head.Add((byte)freqs[j]);
            return head.ToArray();
        }

        private byte[] Compress(byte[] data, string[] codes)
        {
            List<byte> bits = new List<byte>();
            byte sum = 0;
            byte bit = 1;
            foreach (byte symbol in data)
            {
                foreach (char c in codes[symbol])
                {
                    if (c == '1')
                        sum |= bit;
                    if (bit < 128)
                        bit <<= 1;
                    else
                    {
                        bits.Add(sum);
                        sum = 0;
                        bit = 1;
                    }
                }
            }
            if (bit > 1)
                bits.Add(sum);
            return bits.ToArray();
        }

        private int[] CalculateFrequency(byte[] data)
        {
            int[] freqs = new int[256];
            foreach (byte d in data)
                freqs[d]++;
            NormalizeFreqs(freqs);
            return freqs;

            void NormalizeFreqs(int[] freqs)
            {
                int max = freqs.Max();
                if (max < 255) return;
                for (int j = 0; j < 256; j++)
                {
                    if (freqs[j] > 0)
                    {
                        freqs[j] = 1 + freqs[j] * 255 / (max + 1);
                    }
                }
            }
        }

        private Node CreateHuffmanTree(int[] freqs)
        {
            MyPriorityQueue<Node> pq = new();
            for (int j = 0; j < freqs.Length; j++)
            {
                if (freqs[j] > 0)
                {
                    pq.Enqueue(freqs[j], new Node((byte)j, freqs[j]));
                }
            }

            while (pq.Size() > 1)
            {
                Node bit0 = pq.Dequeue();
                Node bit1 = pq.Dequeue();
                int freq = bit0.freq + bit1.freq;
                Node next = new Node(bit0, bit1, freq);
                pq.Enqueue(freq, next);
            }

            return pq.Dequeue();
        }

        private string[] CreateHuffmanCode(Node root)
        {
            string[] codes = new string[256];
            Next(root, "");
            return codes;


            void Next(Node node, string code)
            {
                if (node.bit0 == null)
                {
                    codes[node.symbol] = code;
                    node.code = code;
                }
                else
                {
                    Next(node.bit0, code + "0");
                    Next(node.bit1, code + "1");
                }
            }
        }

        internal (string,string) DecompressFile(string fileName, string dataFilename)
        {
            byte[] arch = File.ReadAllBytes(fileName);
            byte[] data = DecompressBytes(arch);
            File.WriteAllBytes(dataFilename, data);
            string str1 = string.Empty;
            foreach (var b in arch)
                str1 += b.ToString();
            string result = System.Text.Encoding.UTF8.GetString(data);
            return (str1,result);
        }

        private byte[] DecompressBytes(byte[] arch)
        {
            ParseHeader(arch, out int dataLength, out int startIndex, out int[] freqs);
            Node root = CreateHuffmanTree(freqs);
            byte[] data = Decompress(arch, startIndex, dataLength, root);
            return data;
        }

        private byte[] Decompress(byte[] arch, int startIndex, int dataLength, Node root)
        {
            int size = 0;
            Node curr = root;
            List<byte> data = new List<byte>();
            for (int j = startIndex; j < arch.Length; j++)
            {
                for (int bit = 1; bit <= 128; bit <<= 1)
                {
                    bool zero = (arch[j] & bit) == 0;
                    if (zero)
                        curr = curr.bit0;
                    else
                        curr = curr.bit1;
                    if (curr.bit0 != null)
                        continue;
                    if (size++ < dataLength)
                        data.Add(curr.symbol);
                    curr = root;
                }
            }
            return data.ToArray();
        }

        private void ParseHeader(byte[] arch, out int dataLength, out int startIndex, out int[] freqs)
        {
            dataLength = arch[0] |
                (arch[1] << 8) |
                (arch[2] << 16) |
                (arch[3] << 24);
            freqs = new int[256];
            for (int j = 0; j < 256; j++)
            {
                freqs[j] = arch[4 + j];
            }
            startIndex = 4 + 256;
        }
    }
}
