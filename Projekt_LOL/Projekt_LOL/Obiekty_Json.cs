﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_LOL
{

    public class GraczJson
    {
        public long id { get; set;}
        public string name { get; set; }
        public int profileIconId { get; set; }
        public long revisionDate { get; set; }
        public long summonerLevel { get; set; }
    }

    public class ListaGierJson 
    {
        public long summonerId { get; set; }
        public List<GraJson> games { get; set; }
    }

    public class GraJson
    {
        public int championId { get; set; }
        public long createDate { get; set; }
        public List<WspolzawodnicyJson> fellowPlayers { get; set; }
        public long gameId { get; set; }
        public string gameMode { get; set; }
        public string gameType { get; set; }
        public Boolean invalid { get; set; }
        public int ipEarned { get; set; }
        public int level { get; set; }
        public int mapId { get; set; }
        public int spell1 { get; set; }
        public int spell2 { get; set; }
        public StatystykiJson stats { get; set; }
        public string subType { get; set; }
        public int teamId { get; set; }
    }

    public class WspolzawodnicyJson
    {
        public int championId { get; set; }
        public long summonerId { get; set; }
        public int teamId { get; set; }
    }

    public class StatystykiJson
    {
        public int assists { get; set; }
        public int barracksKilled { get; set; }
        public int championsKilled { get; set; }
        public int combatPlayerScore { get; set; }
        public int consumablesPurchased { get; set; }
        public int damageDealtPlayer { get; set; }
        public int doubleKills { get; set; }
        public int firstBlood { get; set; }
        public int gold { get; set; }
        public int goldEarned { get; set; }
        public int goldSpent { get; set; }
        public int item0 { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }
        public int item6 { get; set; }
        public int itemsPurchased { get; set; }
        public int killingSprees { get; set; }
        public int largestCriticalStrike { get; set; }
        public int largestKillingSpree { get; set; }
        public int largestMultiKill { get; set; }
        public int legendaryItemsCreated { get; set; }
        public int level { get; set; }
        public int magicDamageDealtPlayer { get; set; }
        public int magicDamageDealtToChampions { get; set; }
        public int magicDamageTaken { get; set; }
        public int minionsDenied { get; set; }
        public int minionsKilled { get; set; }
        public int neutralMinionsKilled { get; set; }
        public int neutralMinionsKilledEnemyJungle { get; set; }
        public int neutralMinionsKilledYourJungle { get; set; }
        public Boolean nexusKilled { get; set; }
        public int nodeCapture { get; set; }
        public int nodeCaptureAssist { get; set; }
        public int nodeNeutralize { get; set; }
        public int nodeNeutralizeAssist { get; set; }
        public int numDeaths { get; set; }
        public int numItemsBought { get; set; }
        public int objectivePlayerScore { get; set; }
        public int pentaKills { get; set; }
        public int physicalDamageDealtPlayer { get; set; }
        public int physicalDamageDealtToChampions { get; set; }
        public int physicalDamageTaken { get; set; }
        public int quadraKills { get; set; }
        public int sightWardsBought { get; set; }
        public int spell1Cast { get; set; }
        public int spell2Cast { get; set; }
        public int spell3Cast { get; set; }
        public int spell4Cast { get; set; }
        public int summonSpell1Cast { get; set; }
        public int summonSpell2Cast { get; set; }
        public int superMonsterKilled { get; set; }
        public int team { get; set; }
        public int teamObjective { get; set; }
        public int timePlayed { get; set; }
        public int totalDamageDealt { get; set; }
        public int totalDamageDealtToChampions { get; set; }
        public int totalDamageTaken { get; set; }
        public int totalHeal { get; set; }
        public int totalPlayerScore { get; set; }
        public int totalScoreRank { get; set; }
        public int totalTimeCrowdControlDealt { get; set; }
        public int totalUnitsHealed { get; set; }
        public int tripleKills { get; set; }
        public int trueDamageDealtPlayer { get; set; }
        public int trueDamageDealtToChampions { get; set; }
        public int trueDamageTaken { get; set; }
        public int turretsKilled { get; set; }
        public int unrealKills { get; set; }
        public int victoryPointTotal { get; set; }
        public int visionWardsBought { get; set; }
        public int wardKilled { get; set; }
        public int wardPlaced { get; set; }
        public Boolean win { get; set; }
    }
    //https://global.api.pvp.net/api/lol/static-data/eune/v1.2/champion/3?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf
    public class ChampionJson
    {
        public int id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string title { get; set; }
    }
}
