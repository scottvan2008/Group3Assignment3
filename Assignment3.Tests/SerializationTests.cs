using Assignment3.Utility;
using System.Collections.Generic;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
            this.users = new SLL();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);

            Assert.IsTrue(users.Count() == deserializedUsers.Count());

            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }



        private SLL linkedList;

        [SetUp]
        public void SetUp()
        {
            linkedList = new SLL();
        }

        [Test] 
        public void Test_IsEmpty_ReturnsTrue_WhenListIsEmpty()
        {
            Assert.IsTrue(linkedList.IsEmpty());
        }

        [Test] 
        public void Test_AddFirst_PrependsItemToBeginningOfList()
        {
            linkedList.AddFirst(new User(1, "A", "a@e.com", "p1"));
            linkedList.AddFirst(new User(2, "B", "b@e.com", "p2"));

            Assert.AreEqual(2, linkedList.Count());
            Assert.AreEqual("B", linkedList.GetValue(0).Name); 
            Assert.AreEqual("A", linkedList.GetValue(1).Name); 
        }

        [Test] 
        public void Test_AddLast_AppendsItemToEndOfList()
        {
            linkedList.AddLast(new User(1, "A", "a@e.com", "p1"));
            linkedList.AddLast(new User(2, "B", "b@e.com", "p2"));

            Assert.AreEqual(2, linkedList.Count());
            Assert.AreEqual("A", linkedList.GetValue(0).Name);
            Assert.AreEqual("B", linkedList.GetValue(1).Name);
        }

        [Test] 
        public void Test_Add_InsertsItemAtSpecifiedIndex()
        {
            linkedList.AddLast(new User(1, "A", "a@e.com", "p1"));
            linkedList.AddLast(new User(2, "C", "c@e.com", "p3"));
            linkedList.Add(new User(3, "B", "b@e.com", "p2"), 1); 

            Assert.AreEqual(3, linkedList.Count());
            Assert.AreEqual("A", linkedList.GetValue(0).Name);
            Assert.AreEqual("B", linkedList.GetValue(1).Name); 
            Assert.AreEqual("C", linkedList.GetValue(2).Name);
        }

        [Test] 
        public void Test_Replace_ReplacesItemAtIndex()
        {
            linkedList.AddLast(new User(1, "A", "a@e.com", "p1"));
            linkedList.AddLast(new User(2, "B", "b@e.com", "p2"));

            linkedList.Replace(new User(3, "C", "c@e.com", "p3"), 1);

            Assert.AreEqual("C", linkedList.GetValue(1).Name);
        }

        [Test] 
        public void Test_RemoveFirst_RemovesItemFromBeginning()
        {
            linkedList.AddLast(new User(1, "A", "a@e.com", "p1"));
            linkedList.AddLast(new User(2, "B", "b@e.com", "p2"));
            linkedList.RemoveFirst();

            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual("B", linkedList.GetValue(0).Name);
        }

        [Test] 
        public void Test_RemoveLast_RemovesItemFromEnd()
        {
            linkedList.AddLast(new User(1, "A", "a@e.com", "p1"));
            linkedList.AddLast(new User(2, "B", "b@e.com", "p2"));
            linkedList.RemoveLast();

            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual("A", linkedList.GetValue(0).Name);
        }

        [Test] 
        public void Test_Remove_RemovesItemFromMiddle()
        {
            linkedList.AddLast(new User(1, "A", "a@e.com", "p1"));
            linkedList.AddLast(new User(2, "B", "b@e.com", "p2"));
            linkedList.AddLast(new User(3, "C", "c@e.com", "p3"));
            linkedList.Remove(1); 

            Assert.AreEqual(2, linkedList.Count());
            Assert.AreEqual("A", linkedList.GetValue(0).Name);
            Assert.AreEqual("C", linkedList.GetValue(1).Name);
        }

        [Test] 
        public void Test_Contains_FindsExistingItem()
        {
            var user = new User(1, "A", "a@e.com", "p1");
            linkedList.AddLast(user);

            Assert.IsTrue(linkedList.Contains(user));
        }

        [Test] 
        public void Test_Reverse_ReversesTheList()
        {
            linkedList.AddLast(new User(1, "A", "a@e.com", "p1"));
            linkedList.AddLast(new User(2, "B", "b@e.com", "p2"));
            linkedList.AddLast(new User(3, "C", "c@e.com", "p3"));

            linkedList.Reverse();

            Assert.AreEqual("C", linkedList.GetValue(0).Name);
            Assert.AreEqual("B", linkedList.GetValue(1).Name);
            Assert.AreEqual("A", linkedList.GetValue(2).Name);
        }
    }
}