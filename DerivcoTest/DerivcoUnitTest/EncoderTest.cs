using DerivcoTest.Services;
using NUnit.Framework;
using System;

namespace DerivcoUnitTest
{
    [TestFixture]
    public class EncoderTest
    {

        /*
         Question1 question1 = new Question1();
            string test_string = "This is a test string";

            if (question1.CompareString(test_string))            
                Console.WriteLine("Test succeeded");
            else
                Console.WriteLine("Test failed");
        */        
                
        [TestCase("This is a test string")]
        [TestCase("This is a Test String")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("Another string")]
        [TestCase("Another different String")]
        public void CompareStringTest(string testString)
        {
            try
            {
                EncoderService question1 = new EncoderService();

                Assert.IsTrue(question1.CompareString(testString));
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "The String should not be null");
            }            
        }

        [TestCase("This is a test string","TEST1234567890TEST", "TEST1234567890TEST")]
        [TestCase("This is a Test String", "TEST1234567890TEST", "11111111111111111111111111111")]
        [TestCase(null, "TEST1234567890TEST", "11111111111111111111111111111")]
        public void CompareStringTest2(string testString,string encodeKey, string decodeKey)
        {
            try
            {
                EncoderService encoderService = new EncoderService();

                var encoded = encoderService.Encode(testString, encodeKey);

                Assert.IsFalse(encoderService.CompareString(testString, encoded, decodeKey));
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "The String should not be null");
            }
        }
    }
}
