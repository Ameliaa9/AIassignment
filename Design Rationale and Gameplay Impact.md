# AI Design Documentation

## 1. How AI Behaviors Influence Player Strategy and Decision-Making

The AI in my game really makes players think before they move. Since it can see and hear the player, it creates this constant feeling of tension. Players can’t just run around freely—they have to pay attention to the AI’s movements, avoid getting caught in the vision cone, and use the environment to hide or sneak around. It adds a strategic layer where every step feels risky, which makes the experience more intense.

---

## 2. How Player Actions Dynamically Alter AI States and Responses

The AI reacts dynamically depending on what the player does:

- **If the player steps into its vision cone**, the AI **starts chasing**.
- **If the player escapes**, the AI **searches the last seen location** instead of stopping.

This makes encounters feel more realistic and scary. Players can try to outsmart the AI by breaking line of sight or luring it away, which encourages creative problem-solving and gives them control over the situation.

---

## 3. Challenges Faced During Implementation and Their Solutions

### GitHub Not Tracking Unity Changes
At first, GitHub wasn’t tracking changes in my Unity project. I realized it was because I had created the project outside of the GitHub folder.  
*Solution:* I opened the GitHub repo folder directly in Unity. Now, changes are tracked correctly.

### AI Not Detecting the Player
Another issue was the AI not following or detecting the player. After testing, I realized the AI was way too tall, so its vision cone was aimed above the player.  
*Solution:* I resized the AI and increased the detection range. After that, the AI started working properly.

---

