using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

	namespace TreeTraversal{
		
		
		public class Relation {
		
			public string parent;
			public string child;
		
			public Relation(string parent, string child) { 
				this.parent=parent;
				this.child=child;
			}
			
		}
	
	public class myDataStruct{
		
			public Dictionary<string,int> hashtable = new Dictionary<string,int>();
			public List<string> dictValues=new List<string>();
		
		
			public Object getRandomElement(){
			Random random =new Random();
			
			
			return dictValues[random.Next(0,dictValues.Count)];
			}
		
		
			public void insertElement(string x){
			this.hashtable.Add(x,this.dictValues.Count+1);
			this.dictValues.Add(x);
			
		}
			public  void removeElement(string x){
			this.dictValues.RemoveAt(this.hashtable[x]);
			this.hashtable.Remove(x);
			
		} 
			
		
			public myDataStruct(){
			this.hashtable["One"] = 1;
			this.hashtable["Two"] = 2;
			this.hashtable["Three"] = 3;
			foreach(KeyValuePair<string,int> kv in hashtable){
				Console.Write("   Key "+kv.Key+ " : "+kv.Value +" Value \n");
			
			}
		
			dictValues.Add("One");
			dictValues.Add("Two");
			dictValues.Add("Three");
			
			}
		
		
		
		
	}
	
		
	public class TreePrinter {
		
		myDataStruct m =new myDataStruct();
	/*	
		public static int[] Sort(int[] array)
{
    return RadixSortAux(array, 1);
}
        static int[] RadixSortAux(int[] array, int digit)
        {
            bool Empty = true;
            KVEntry[] digits = new KVEntry[array.Length];//array that holds the digits;
            int[] SortedArray = new int[array.Length];//Hold the sorted array
            for (int i = 0; i < array.Length; i++)
            {
                digits[i] = new KVEntry();
                digits[i].Key = i;
                digits[i].Value = (array[i] / digit) % 10;
                if (array[i]/digit!=0)
                    Empty = false;
            }

            if (Empty)
                return array;

            KVEntry[] SortedDigits = CountingSort(digits);
            for (int i = 0; i < SortedArray.Length; i++)
                SortedArray[i] = array[SortedDigits[i].Key];
            return RadixSortAux(SortedArray, digit * 10);
        } 
	
	*/	
		public static void Main(string[] args) {
			
			
			
			myDataStruct m =new myDataStruct();
		
			//list of relations
			List<Relation> input = new List<Relation>();
			input.Add(new Relation("animal","mammal"));
			input.Add(new Relation("animal","bird"));
			input.Add(new Relation("lifeform","animal"));
			input.Add(new Relation("cat","lion"));
			input.Add(new Relation("mammal","cat"));
			input.Add(new Relation("animal","fish"));
	
			TreePrinter t = new TreePrinter();
			t.printTree(input);
			
			
			//Misc test stuff
	
			
			
			}
		
		public void printTree(List<Relation> relations){
			
			HashSet<string> setOfNotRootElements = new HashSet<string>();
			//build a tree using HashMap. You can also build the tree 
			//put a Map inside a Map, but this seems simpler.
			Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
			
			foreach(Relation r in relations){
				List<string> children =  new List<string>();
				if(dict.ContainsKey(r.parent)){
					children = dict[r.parent]; //if parent already present ,get the child list and append to it
				}
				children.Add(r.child);
				dict[r.parent]= children;//mutable add the dictionary again with the new child set
				//keeping track of children..
				setOfNotRootElements.Add(r.child);
					}
				//find the root
				string root="" ;
				foreach(Relation r in relations){
				 if(!(setOfNotRootElements.Contains(r.parent))){
					root=r.parent;
			      }}
			
				foreach (KeyValuePair<string,List<string>> kv in dict)	{
					Console.Write("Key is "+ kv.Key +"  Children are "+ string.Join(",", kv.Value.ToArray())+"\n");
				}	
				printNode(root, dict);
			}
		
		
					public void printNode(string parent, Dictionary<string, List<string>> map){
					System.Console.Write(parent+" \n");
					List<string> children = map[parent];
					if(children != null){
						foreach (string child in children){
							 if(map.ContainsKey(child))
								printNode(child, map);
								else{
								System.Console.Write(child+" \n");
								}
						}
					}
				}
			}
	 
	}
