using System;

namespace GD.Types
{
    /// <summary>
    /// Represents the various types of waypoints that can be used in the game.
    /// </summary>
    public enum WaypointType
    {
        [Description("Waypoint designated for setting up an ambush.")]
        Ambush,

        [Description("Waypoint indicating an alert or investigation state.")]
        Alert,

        [Description("Waypoint marking an attack or combat position.")]
        Attack,

        [Description("Waypoint designating a defensive position.")]
        Defend,

        [Description("Waypoint marking an area to explore.")]
        Explore,

        [Description("Waypoint used when the entity needs to flee from danger.")]
        Flee,

        [Description("Waypoint where the entity idles without specific orders.")]
        Idle,

        [Description("Waypoint indicating a location to investigate suspicious activity.")]
        Investigate,

        [Description("Waypoint where the entity interacts with an object or environment.")]
        Interact,

        [Description("Waypoint used for patrolling behavior.")]
        Patrol,

        [Description("Waypoint for meeting or rendezvousing with allies.")]
        Rendezvous,

        [Description("Waypoint where the entity rests or idles.")]
        Rest,

        [Description("Waypoint to seek cover from enemy fire or hazards.")]
        SeekCover
    }

    /// <summary>
    /// Represents the various types of NPC units that can be found in the game.
    /// </summary>
    [Flags]
    public enum UnitType
    {
        [Description("No specific NPC type selected.")]
        None = 0,

        [Description("Friendly AI that assists the player.")]
        Ally = 1 << 0,

        [Description("Civilians who roam the world and interact with the environment.")]
        Civilian = 1 << 1,

        [Description("Hostile enemies that attack the player and allies.")]
        Enemy = 1 << 2,

        [Description("Guards who patrol specific areas and respond to threats.")]
        Guard = 1 << 3,

        [Description("Merchants that trade items, weapons, or resources.")]
        Merchant = 1 << 4,

        [Description("Workers performing tasks like farming, crafting, or mining.")]
        Worker = 1 << 5,

        [Description("Engineers who repair structures, vehicles, or weapons.")]
        Engineer = 1 << 6,

        [Description("Quest-giving NPCs who provide objectives and rewards.")]
        QuestGiver = 1 << 7,

        [Description("NPCs that act as vendors in various shops.")]
        Shopkeeper = 1 << 8,

        [Description("NPCs that provide transportation services, such as ferry or taxi drivers.")]
        Transporter = 1 << 9,

        [Description("Elite bosses with stronger abilities and unique AI behaviors.")]
        Boss = 1 << 10,

        [Description("Random travelers or wanderers moving between locations.")]
        Wanderer = 1 << 11,

        [Description("Wild animals that interact with the environment and players.")]
        Wildlife = 1 << 12
    }

    /// <summary>
    /// Represents the possible buff types that can be applied to a player or object when using a consumable item.
    /// </summary>
    public enum BuffType : sbyte
    {
        [Description("Boosts attack damage for a short duration.")]
        AttackBoost,

        [Description("Reduces damage taken for a short duration.")]
        DamageReduction,

        [Description("Temporarily increases defense.")]
        DefenseBoost,

        [Description("Regenerates health over time.")]
        HealthRegen,

        [Description("Increases jump height.")]
        JumpBoost,

        [Description("Increases movement speed temporarily.")]
        SpeedBoost,

        [Description("Improves stamina regeneration.")]
        StaminaRegen
    }

    /// <summary>
    /// Represents the various types of selection strategies that can be used to choose an item from a list.
    /// </summary>
    public enum SelectionStrategy : sbyte
    {
        [Description("Select the first item in the list.")]
        First,

        [Description("Select the last item in the list.")]
        Last,

        [Description("Select a random item from the list.")]
        Random,

        [Description("Cycle sequentially through the list.")]
        Cycle,

        [Description("Select a random item based on assigned weights.")]
        WeightedRandom,

        [Description("Select a random item ensuring no repeats until all items have been selected.")]
        RandomNoRepeat,

        [Description("Select an item based on elapsed time intervals.")]
        TimeBasedChange
    }

    /// <summary>
    /// Represents the discrete game states that the player can be in.
    /// </summary>
    public enum GameState : sbyte
    {
        Playing,
        Won,
        Lost,
        Respawn
    }

    /// <summary>
    /// Represents the various types of audio groups in the game.
    /// </summary>
    public enum AudioMixerGroupName : sbyte
    {
        [Description("Master audio group")]
        Master,

        [Description("Ambient sounds group")]
        Ambient,

        [Description("Background music group")]
        Background,

        [Description("Sound effects group")]
        SFX,

        [Description("UI sounds group")]
        UI,

        [Description("Voiceover group")]
        Voiceover,

        [Description("Weapon sounds group")]
        Weapon
    }

    /// <summary>
    /// Represents the state of a UI element, such as visible, hidden, or transitioning.
    /// </summary>
    public enum VisibilityState : sbyte
    {
        [Description("The UI element has tween applied.")]
        End,

        [Description("The UI element is transitioning to a visible state.")]
        Showing,

        [Description("The UI element is transitioning to a hidden state.")]
        Hiding,

        [Description("The UI element has not yet had tween applied.")]
        Start
    }

    /// <summary>
    /// Used in the GameStateManager to determine how to evaluate a condition.
    /// </summary>
    public enum LogicType : sbyte
    {
        [Description("Evaluate all conditions and return true if all are met.")]
        AND,

        [Description("Evaluate all conditions and return true if any are met.")]
        OR,

        [Description("Evaluate all conditions and return true if only one is met.")]
        XOR
    }

    /// <summary>
    /// Used in the StateManager to determine how to evaluate a condition.
    /// </summary>
    public enum EvaluateStrategy : sbyte
    {
        /// <summary>
        /// Always evaluate the condition, regardless of whether it is met.
        /// </summary>
        [Description("Always evaluate the condition, regardless of whether it is met.")]
        EvaluateAlways,

        /// <summary>
        /// Evaluate the condition until it is met, then stop evaluating.
        /// </summary>
        [Description("Evaluate the condition until it is met, then stop evaluating.")]
        EvaluateUntilMet
    }

    /// <summary>
    /// A five-level priority system used to determine the importance of a task, event, or object.
    /// </summary>
    public enum PriorityLevel : sbyte
    {
        [Description("This is the highest priority.")]
        Highest = 1,

        [Description("This is a high priority.")]
        High = 2,

        [Description("This is a medium priority.")]
        Medium = 3,

        [Description("This is a low priority.")]
        Low = 4,

        [Description("This is the lowest priority.")]
        Lowest = 5
    }

    /// <summary>
    /// Defines the various high-level categories of list available in a game.
    /// Each category groups similar item types under one classification.
    /// </summary>
    /// <see cref="GD.Items.ItemData"/>
    /// <see cref="GD.Inventory"/>
    public enum ItemCategoryType : sbyte
    {
        /// <summary>
        /// Items that restore health, provide armor, or give temporary boosts.
        /// </summary>
        [Description("Items that restore health, provide armor, or give temporary boosts")]
        Consumable,

        /// <summary>
        /// Decorative or collectible list that enhance the game environment or act as achievements.
        /// </summary>
        [Description("Items that are purely decorative or collectible")]
        Decorative,

        /// <summary>
        /// Items that can be deployed or used in the environment for strategic purposes.
        /// </summary>
        [Description("Items that can be deployed or used in the environment for strategic purposes")]
        Deployable,

        /// <summary>
        /// Items that can be equipped by the player, like weapons or armor.
        /// </summary>
        [Description("Items that can be equipped by the player, like weapons or armor")]
        Equippable,

        /// <summary>
        /// Items that can be interacted with to perform actions or affect the game environment.
        /// </summary>
        [Description("Items that can be interacted with to perform actions or affect the game environment")]
        Interactable,

        /// <summary>
        /// Items that provide information, lore, or serve as blueprints.
        /// </summary>
        [Description("Items that provide information or serve as instructions or blueprints")]
        Informative,

        /// <summary>
        /// Items used to unlock or solve puzzles or progress the storyline.
        /// </summary>
        [Description("Items used to unlock or solve puzzles or progress the storyline")]
        PuzzleItem,

        /// <summary>
        /// Items that serve as key resources, such as food, water, building materials, or power.
        /// </summary>
        [Description("Items that serve as resources or crafting materials")]
        Resource,

        /// <summary>
        /// Weapons used for attacking or defending.
        /// </summary>
        [Description("Items that can be used for attacking or defense")]
        Weapon,

        /// <summary>
        /// Items that are used for navigation or wayfinding.
        /// </summary>
        [Description("Items that are used for navigation or wayfinding")]
        Waypoint
    }

    /// <summary>
    /// Defines the various specific types of list available in a game.
    /// These types are grouped under the broader categories represented by ItemCategoryType.
    /// </summary>
    /// <see cref="GD.Items.ItemData"/>
    /// <see cref="GD.Inventory"/>
    public enum ItemType : sbyte
    {
        // Consumable Types
        /// <summary>
        /// Represents an armor vest providing additional protection.
        /// </summary>
        [Description("Armor vest providing additional protection to the player")]
        Armor,

        /// <summary>
        /// Represents a health item used to restore player health.
        /// </summary>
        [Description("Health item used to restore player health")]
        HealthPack,

        /// <summary>
        /// Represents a medkit or similar item that provides a large health boost.
        /// </summary>
        [Description("Medkit providing a significant health boost")]
        Medkit,

        /// <summary>
        /// Represents a consumable item that provides temporary boosts like increased speed or strength.
        /// </summary>
        [Description("Consumable item providing temporary boosts like increased speed or strength")]
        PowerUp,

        // Decorative Types
        /// <summary>
        /// Represents a collectible item that can serve as an achievement or reward.
        /// </summary>
        [Description("Collectible item that acts as an achievement or reward")]
        Collectible,

        /// <summary>
        /// Represents a decorative item such as a plant or statue.
        /// </summary>
        [Description("Decorative item used to enhance the game environment")]
        DecorativeItem,

        // Deployable Types
        /// <summary>
        /// Represents a throwable tactical item such as a flashbang or smoke grenade.
        /// </summary>
        [Description("Throwable tactical item like a flashbang or smoke grenade")]
        TacticalItem,

        /// <summary>
        /// Represents a trap or mine that can be deployed for tactical advantage.
        /// </summary>
        [Description("Trap or mine used for tactical advantage")]
        Trap,

        /// <summary>
        /// Represents a deployable object such as a turret or barricade.
        /// </summary>
        [Description("Deployable object such as a turret or barricade")]
        Turret,

        // Equippable Types
        /// <summary>
        /// Represents a piece of armor that can be equipped by the player.
        /// </summary>
        [Description("Armor that can be equipped by the player")]
        EquippableArmor,

        /// <summary>
        /// Represents a firearm weapon that can be equipped.
        /// </summary>
        [Description("Firearm weapon such as a pistol, rifle, or shotgun that can be equipped")]
        EquippableFirearm,

        /// <summary>
        /// Represents a melee weapon such as a knife or crowbar that can be equipped.
        /// </summary>
        [Description("Melee weapon such as a knife or crowbar that can be equipped")]
        EquippableMeleeWeapon,

        // Informative Types
        /// <summary>
        /// Represents a blueprint or recipe used to create or upgrade an item.
        /// </summary>
        [Description("Blueprint or recipe for creating or upgrading items")]
        Blueprint,

        /// <summary>
        /// Represents a clue or hint used to assist in solving puzzles.
        /// </summary>
        [Description("Clue or hint used to assist in solving puzzles")]
        Clue,

        /// <summary>
        /// Represents a note or document providing lore or game information.
        /// </summary>
        [Description("Note or document providing lore or important information")]
        Document,

        // Interactable Types
        /// <summary>
        /// Represents a door that can be opened or closed by the player.
        /// </summary>
        [Description("Door that can be opened or closed by the player")]
        Door,

        /// <summary>
        /// Represents a lever or button that can be activated to trigger mechanisms.
        /// </summary>
        [Description("Lever or button that can be activated to trigger mechanisms")]
        Lever,

        /// <summary>
        /// Represents a switch that changes the state of something in the game environment.
        /// </summary>
        [Description("Switch that changes the state of something in the game environment")]
        Switch,

        // Puzzle Item Types
        /// <summary>
        /// Represents an artifact or object used to activate or solve puzzles.
        /// </summary>
        [Description("Artifact used to activate or solve puzzles")]
        Artifact,

        /// <summary>
        /// Represents a key or access card used to unlock doors or access restricted areas.
        /// </summary>
        [Description("Key or access card used to unlock doors or access restricted areas")]
        Key,

        /// <summary>
        /// Represents a puzzle piece that is part of a larger puzzle.
        /// </summary>
        [Description("Puzzle piece used to complete a puzzle")]
        PuzzlePiece,

        // Resource Types
        /// <summary>
        /// Represents a building material such as wood or steel used for construction.
        /// </summary>
        [Description("Building material such as wood or steel used for construction")]
        BuildingMaterial,

        /// <summary>
        /// Represents a crafting component that can be used to create or upgrade list.
        /// </summary>
        [Description("Crafting component for creating or upgrading items")]
        CraftingComponent,

        /// <summary>
        /// Represents a general resource such as food, water, or fuel.
        /// </summary>
        [Description("Resource item used in simulation games, such as food, water, or fuel")]
        Resource,

        // Weapon Types
        /// <summary>
        /// Represents ammunition used for reloading firearms.
        /// </summary>
        [Description("Ammunition used for reloading firearms")]
        Ammo,

        /// <summary>
        /// Represents a firearm weapon such as a pistol, rifle, or shotgun.
        /// </summary>
        [Description("Firearm weapon such as a pistol, rifle, or shotgun")]
        Firearm,

        /// <summary>
        /// Represents a melee weapon such as a knife or crowbar.
        /// </summary>
        [Description("Melee weapon such as a knife or crowbar")]
        MeleeWeapon,

        /// <summary>
        /// Represents a special weapon such as a rocket launcher or sniper rifle.
        /// </summary>
        [Description("Special weapon such as a rocket launcher or sniper rifle")]
        SpecialWeapon
    }
}