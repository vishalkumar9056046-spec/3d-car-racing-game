# 3D Car Racing Game

Android 3D car racing game developed in Unity with multiple vehicles, tracks, and gameplay features.

## Features

### Gameplay
- **Multiple Cars**: 5 different car types with unique stats
  - Sports Car (Free)
  - Truck (500 coins)
  - Formula (1000 coins)
  - SUV (1500 coins)
  - Hypercar (2500 coins)

- **5 Challenging Levels**: Progressive difficulty from beginner to extreme

- **Nitro Boost**: Temporary speed boost with cooldown recharge system

- **Coin Collection**: Collect coins throughout the track for rewards

- **Car Shop**: Purchase and unlock new vehicles

### Controls

#### Desktop
- **Arrow Keys**: Steer left/right
- **W/Up Arrow**: Accelerate
- **S/Down Arrow**: Brake
- **Spacebar**: Nitro Boost
- **Esc**: Pause

#### Mobile (Android)
- **Accelerometer**: Steer left/right
- **Touch Upper Half**: Accelerate
- **Touch Lower Half**: Brake
- **Multi-Touch**: Nitro Boost
- **Back Button**: Pause

## Project Structure

```
Assets/
├── Scripts/
│   ├── GameManager.cs              # Core game management
│   ├── CarController.cs            # Vehicle physics and input
│   ├── InputManager.cs             # Mobile and desktop input
│   ├── UI/
│   │   ├── MainMenuUI.cs
│   │   ├── PauseMenuUI.cs
│   │   ├── GameOverUI.cs
│   │   ├── HUD.cs
│   │   ├── CarShopUI.cs
│   │   └── SettingsUI.cs
│   ├── Collectibles/
│   │   ├── CoinCollector.cs
│   │   ├── FinishLine.cs
│   │   └── Obstacle.cs
│   ├── Camera/
│   │   └── FollowCamera.cs
│   ├── Environment/
│   │   ├── TrackManager.cs
│   │   ├── Checkpoint.cs
│   │   └── LevelLoader.cs
│   ├── Audio/
│   │   └── AudioManager.cs
│   ├── Vehicles/
│   │   ├── CarStats.cs
│   │   └── CarSelector.cs
│   └── Effects/
│       └── ParticleEffectManager.cs
├── Prefabs/
│   ├── Cars/
│   │   └── SportsCar.prefab
│   └── Coins/
│       └── Coin.prefab
├── Materials/
│   ├── CarRed.mat
│   └── CoinGold.mat
├── Scenes/
│   ├── MainMenu.unity
│   ├── CarShop.unity
│   ├── Settings.unity
│   ├── Level_1.unity
│   ├── Level_2.unity
│   ├── Level_3.unity
│   ├── Level_4.unity
│   └── Level_5.unity
└── Audio/
    └── (Add audio files here)
```

## Getting Started

1. **Open in Unity**: Open the project in Unity 2020.3+ LTS

2. **Configure Android**:
   - Set target platform to Android in Build Settings
   - Set minimum SDK to 21 (Android 5.0)
   - Set target SDK to 31 (Android 12)

3. **Build and Run**:
   - Connect Android device or use emulator
   - Build and Run to test on device

## Game Systems

### Physics System
- Realistic car acceleration and deceleration
- Steering with visual feedback
- Brake system with increased drag
- Gravity and collision detection

### Progression System
- 5 levels with increasing difficulty
- Coin collection and rewards
- Car unlock system
- Best time tracking

### Audio System
- Engine sounds
- Nitro boost sound
- Coin collection feedback
- Crash sound effects
- Level completion jingle

## Customization

### Car Stats
Edit `CarController.cs` to modify:
- Max speed
- Acceleration
- Handling
- Weight
- Prices

### Level Difficulty
Edit `LevelLoader.cs` to adjust:
- Obstacle density
- Track hazards
- Time limits
- Coin placement

## Development Notes

- All scripts include comments for easy modification
- Modular design allows for easy feature additions
- PlayerPrefs used for save data
- Supports both mobile and desktop platforms

## Future Enhancements

- [ ] Online leaderboards
- [ ] Multiplayer racing
- [ ] Custom track editor
- [ ] Additional car customization
- [ ] Power-up system
- [ ] Weather effects
- [ ] Night mode racing

## License

This project is open source and available for modification and distribution.
