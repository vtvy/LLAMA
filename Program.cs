using LLama;
using LLama.Common;
using System.Security.Cryptography;
using System.Text;

var modelPathE = @"D:\code\bot-gpt\models\llama-2-7b-guanaco-qlora.Q4_K_M.gguf";
var modelPath = @"D:\Downloads\llama-2-7b-chat.Q4_K_M.gguf";
//var modelPath = @"D:\code\bot-gpt\models\llama-2-13b-chat.Q4_K_M.gguf";
//var modelPath = @"D:\Downloads\nous-hermes-llama2-13b.Q4_0.gguf";

// Load weights into memory

Console.WriteLine("What is your question");
var question = Console.ReadLine();
Console.WriteLine(question);
var inferenceParams = new InferenceParams() { Temperature = 0.6f, MaxTokens = 1000 };
var contextValue = new StringBuilder();

while (question != null && question != "exit")
{
    var parameters = new ModelParams(modelPath)
    {
        ContextSize = 10000,
        Seed = unchecked(RandomNumberGenerator.GetInt32(int.MaxValue)),
        GpuLayerCount = 5,
    };

    using var model = LLamaWeights.LoadFromFile(parameters);

    var parametersE = new ModelParams(modelPathE)
    {
        ContextSize = 1024,
        Seed = unchecked(RandomNumberGenerator.GetInt32(int.MaxValue)),
        GpuLayerCount = 5,
    };

    using var modelE = LLamaWeights.LoadFromFile(parametersE);
    using var context = model.CreateContext(parameters);
    var ex = new InteractiveExecutor(context);

    // Initialize a chat session
    // ChatSession session = new ChatSession(ex);

    //var vectorStore = await SqliteMemoryStore.ConnectAsync("db.sqlite");

    //var embedding = new LLamaEmbedder(modelE, parametersE);

    //var memory = new MemoryBuilder()
    //    .WithTextEmbeddingGeneration(new LLamaSharpEmbeddingGeneration(embedding))
    //    .WithMemoryStore(vectorStore)
    //    .Build();

    //const string MemoryCollectionName = "ai";

    //await memory.SaveInformationAsync(MemoryCollectionName, id: "1", text: "Owner of this application is Vo Trieu Vy");



    //var contextInformation = memory.SearchAsync(MemoryCollectionName, question, limit: 100, minRelevanceScore: 0.1);

    //await foreach (var item in contextInformation)
    //{
    //    Console.WriteLine("Result");
    //    Console.WriteLine(item.Metadata.ToString());
    //    contextValue.Append(item.Metadata.Text);
    //}
    //var prompt = @$"
    //Information about me, from previous conversations:
    //{contextValue}
    //Question: {question}
    //Answer: ";
    //Console.WriteLine(prompt);
    //await foreach (var text in ex.InferAsync(prompt, inferenceParams))
    //{
    //    Console.Write(text);
    //}

    StringBuilder prompt = new("Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob is helpful, kind, honest, good at writing, and never fails to answer the User's requests immediately and with precision.");


    if (true)
    {
        var userHistory = "Hello, Bob";
        var answerHistory = "Hello. How may I help you today?";
        prompt.AppendLine($"User: {userHistory}");
        prompt.AppendLine($"Bob: {answerHistory}");
    }

    prompt.AppendLine("Please read the following information then answer me base on that.");
    prompt.AppendLine("How to Communicate Effectively\r\nNo matter your age, background, or experience, effective communication is a skill you can learn. Some of the greatest leaders of all time are also fantastic communicators and orators. In fact, communications is one of the most popular college degrees today; people recognize the value of a truly efficient communicator. With a little self-confidence and knowledge of the basics, you'll be able to get your point across quickly and easily.\r\n\r\nCreating the Right Environment\r\n1. Choose the right time. As the saying states, there is a time and a place for everything, and communicating is no different.\r\nAvoid starting discussions about heavy topics late in the evening. Few people will be thrilled to be faced with sorting major issues like finances or long range scheduling when they are the most tired. Instead, deliver messages and conduct discussions about heavy topics in the mornings or afternoons when people are alert, available, and more likely to be able to respond with clarity.\r\n\r\n2. Facilitate an open, intimate conversation. Choose the right place, one that provides freedom for the communication to open, flower, and come to maturity. If you need to tell someone something that isn't going to sit well (such as news of a death or a breakup), don't do it in public, around colleagues, or near other people. Be respectful and mindful of the person by communicating to them in a private place. This will also provide space to open the dialog into a wider and a more involved mutual understanding and ensure that the two-way process is functioning properly.\r\nIf you are presenting to a group of people, be sure to check the acoustics beforehand and practice projecting your voice clearly. Use a microphone if needed to ensure that your audience can hear you.\r\n\r\n3. Remove distractions. Turn off all electronics that could interrupt the conversation. If the phone rings, laugh it off the first time, then turn it off immediately and continue talking. Do not allow external distractions to act as crutches that sidetrack your concentration. They will distract both you and your listener, and will effectively kill the communication.\r\n\r\nOrganizing your communications\r\n1. Organize and clarify ideas in your mind. This should be done before you attempt to communicate any ideas. If you are feeling passionate about a topic, your ideas may become garbled if you haven't already targeted some key points to stick to when communicating. Key points will act as anchors, bringing focus and clarity to your communication.\r\nA good rule of thumb is to choose three main points and keep your communication focused on those. That way, if the topic wanders off course, you will be able to return to one or more of these three key points without feeling flustered. Writing the points down, if appropriate, can also help.\r\n\r\n2. Be crystal clear. Make it clear what you're hoping to convey from the outset. For example, your purpose could be to inform others, obtain information, or initiate action. If people know in advance what you expect from the communication, things will go more smoothly.\r\n\r\n3. Stay on topic. Once you start to convey your three main points, make sure everything you're saying adds to the message you intend to communicate and strengthens it. If you have already thought through the issues and distilled the them to the essentials, it is likely that helpful pertinent phrases will stick in your mind. Do not be afraid to use these to underline your points. Even confident, well-known speakers reuse their key lines again and again for emphasis and reinforcement. Remember to keep the overall message clear and direct.\r\n\r\n4. Thank your listener(s). Thank the person or group for the time taken to listen and respond. No matter what the outcome of your communication, even if the response to your talk or discussion has been other than you had hoped, end it politely by properly respecting everyone's input and time.\r\n\r\nCommunicating with Speech\r\n1. Set the listener at ease. You want to do this before launching into your conversation or presentation. It can help sometimes to begin with a favorite anecdote. This helps the listener identify with you as someone who acts like them and has the same everyday concerns.\r\n\r\n2. Be articulate. It is important to deliver your message clearly and unambiguously so that the message comes across in a way that every listener can understand. Your words are remembered because people instantly understand what it is that you are saying. This requires delivering your words distinctly and using simpler words rather than more complex ones.\r\nThe goal of articulate communication is to be clear, concise and relevant.\r\n\r\n3. Enunciate clearly. Speak at a volume level that is guaranteed to be heard and that doesn't come across as too quiet or disengaged. Take special care to properly enunciate key points so that you avoid any kind of misunderstanding. If mumbling is a defensive habit that you have fallen into due to fear of communicating, practice your message at home in front of the mirror. It is sometimes best to discuss what you want to communicate with those you feel comfortable with. This helps solidify the message in your own mind. Be aware that any practice or refinement of your wording will help you to build confidence.\r\n\r\n4. Be attentive when listening and ensure that your facial expressions reflect your interest. Listen actively. Remember that communication is a two-way street and that while you are talking, you are not learning. By actively listening, you will be able to gauge how much of your message is getting through to your listener(s) and whether or not it is being received correctly or needs to be tweaked. If your audience appears to be confused, it is often helpful to ask the listener(s) to reflect back some of what you have said, but in their own words. This can help you to identify and correct mistaken views of what you have intended to communicate.\r\nValidate people's feelings. This will encourage them to open up, and help them feel better if they're upset.\r\n\r\n5. Be vocally interesting. A monotone is not pleasing to the ear, so good communicators use vocal color to enhance communication. Norma Michael recommends[1] that you:\r\nRaise the pitch and volume of your voice when you transition from one topic or point to another.\r\nIncrease your volume and slow the delivery whenever you raise a special point or are summing up.\r\nSpeak briskly, but pause to emphasize keywords when requesting action.\r\n\r\nCommunicating with Body Language\r\n1. Recognize people. Sure, you don't necessarily know the people in your audience or that new friend in your group, but they're nodding along with you and looking knowingly at you all the same. This means that they are connecting with you. So reward them with your acknowledgment!\r\n\r\n2. Be clear and unambiguous with your body language, too. Use facial expressions consciously. Strive to reflect passion and generate listener empathy by using soft, gentle, aware facial expressions. Avoid negative facial expressions, such as frowns or raised eyebrows. What is or isn't negative depends on the context, particularly the cultural context, so be guided by your situation.\r\nBe quick to identify unexpected behavior that suggests a cross-culture collision, such as a clenched fist, a slouched posture, or even silence.[2] If you don't know the culture intimately, ask questions about the communication challenges you might face before you start to speak with (or to) people in an unfamiliar cultural context.\r\n\r\n3. Communicate eye-to-eye. Eye contact builds rapport, helps to convince people that you're trustworthy, and displays interest. During a conversation or presentation, it is important to look into the other person's eyes if possible and maintain contact for a reasonable amount of time. Take care not to overdo it.– Use just as much eye contact as feels natural, about 2-4 seconds at a time.[3]\r\nRemember to take in all of your audience. If you're addressing a boardroom, look every member of the board in the eye. Neglecting any single person can easily be taken as a sign of offense and could lose you business, admission, success, or whatever it is you endeavor to achieve.\r\nIf you're addressing an audience, pause and make eye contact with a member of audience for up to two seconds before breaking away and resuming your talk. This helps individual members of the audience feel personally valued.\r\nBe aware that eye contact is culturally ordained. In some cultures it is considered to be unsettling, or inappropriate. Ask about this in particular or do the research in advance.\r\n\r\n4. Use breathing and pauses to your advantage. There is power in pausing. Simon Reynolds says that pausing causes an audience to lean in and listen. It helps you to emphasize your points and allow the listener time to digest what has been said. It also helps to make your communication come across as more compelling and it makes your speech easier to absorb and become comfortable with.[4]\r\nTake a few deep breaths to steady yourself before you begin communicating.\r\nGet into the habit of solid, regular breathing during a conversation, This will help you to keep a steady, calm voice and will also keep you more relaxed.\r\nUse pauses to take a breather from what you are saying.\r\n\r\n5. Consider how your gestures come across. Use hand gestures carefully. Be conscious of what your hands are saying as you speak. Some hand gestures can be very effective in highlighting your points (open gestures), while others can be distracting or even offensive to some listeners, and tend to shut down the conversation or listening (closed gestures). It also helps to watch other speaker's hand gestures with an eye for how they come across to you. Emulate those you see that are effective and engaging. Notice that the most effective gestures are natural, slow, and emphatic.\r\n\r\n6. Keep a check on your other body signals. Be alert to your wandering eyes, your hands picking at fluff, your constant sniffling, shuffling, rocking, and the like. These small gestures add up and are all guaranteed to dampen the effectiveness of your message.\r\nHave someone record your talk, then take the time to view your speech delivery in fast forward. Any repetitive gesture or unconscious habit will stand out like a sore thumb and will be somewhat comical. Once you have targeted such a behavior, it will be easier to modify your unintended body language and monitor its reappearance.\r\n\r\nCommunicating Effectively When in Conflict\r\n1. Place yourself on even ground. Do not stand or hover over the other person. This creates a power struggle and pushes the conflict to another level. If they are sitting, you should sit with them.\r\n\r\n2. Listen to the other party. Let them say how they feel. Wait until they are completely finished talking before beginning to speak yourself.\r\n\r\n3. Speak in a calm, level voice. Don't yell or make accusations about the other party or their actions.\r\n\r\n4. Let them know you have heard their point and understand their side. Take the time to make statements like, \"If I understand correctly, you are saying,...\"\r\n\r\n5. Don't try to finish the argument at all costs. If the person walks out of the room, don't follow them. Allow them to do so and let them return when they are calmer and ready to talk.\r\n\r\n6. Don't try to get the last word in. Again, this could lead to a power struggle that escalates and never ends. Sometimes, you have to agree to disagree and move on.\r\n\r\n7. Use \"I\" messages. When you're phrasing your concerns, try to start your sentences with \"I...\" and state clearly how their actions make you feel. This will make the other person more receptive to your complaints and more empathetic. For instance, instead of saying \"You're sloppy and it drives me crazy,\" try \"I feel that different levels of messiness might be a problem for us. Clutter is something that seems to work its way into my mind and limit what I feel I can do. Frankly, messiness seems to unsettle me more than it probably should.\"\nAuthor is Vo Trieu Vy");

    prompt.AppendLine($"User: {question}");
    var inferenceParamss = new InferenceParams() { Temperature = 0.6f, AntiPrompts = new string[] { "User:", "\n\n" }, MaxTokens = 200 };

    await foreach (var output in ex.InferAsync(prompt.ToString(), inferenceParamss))
    {
        Console.Write(output);
    }
    contextValue.Clear();
    Console.WriteLine("\nWhat is your question");
    question = Console.ReadLine();
}

//// run the inference in a loop to chat with LLM
//while (prompt != "stop" && prompt != null)
//{
//    foreach (var text in session.Chat(prompt, new InferenceParams() { Temperature = 0.6f, AntiPrompts = new List<string> { "User:" } }))
//    {
//        Console.Write(text);
//    }
//    prompt = Console.ReadLine();
//}

//// save the session
//session.SaveSession("SavedSessionPath");