using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using projectWith中佑.Models;

namespace projectWith中佑
{
    public class SlotMachineHub : Hub
    {
        SlotGameWebEntities2 db = new SlotGameWebEntities2();
        public void SymbolSlot(
            int p0, int p1, int p2,
            int p3, int p4, int p5,
            int p6, int p7, int p8,
            int p9, int p10, int p11,
            int p12, int p13, int p14,
            int bingoLine1, int bingoLine2,
            int bingoLine3, int bingoLine4, int bingoLine5,
            int bingoLine6, int bingoLine7, int bingoLine8,
            int bingoLine9, int bingoLine10, int bingoLine11,
            int bingoLine12, int bingoLine13, int bingoLine14,
            int bingoLine15, int bingoLine16, int bingoLine17,
            int bingoLine18, int bingoLine19, int bingoLine20,
             int credits, int win, int bet, int line, int totalBet, int memberId)
        {
            if (credits >= totalBet && totalBet > 0)
            {
                credits = credits - totalBet;
                win = 0;

                p0 = IntUtil.Radom(0, 14);
                p1 = IntUtil.Radom(0, 14);
                p2 = IntUtil.Radom(0, 14);

                p3 = IntUtil.Radom(0, 14);
                p4 = IntUtil.Radom(0, 14);
                p5 = IntUtil.Radom(0, 14);

                p6 = IntUtil.Radom(0, 14);
                p7 = IntUtil.Radom(0, 14);
                p8 = IntUtil.Radom(0, 14);

                p9 = IntUtil.Radom(0, 14);
                p10 = IntUtil.Radom(0, 14);
                p11 = IntUtil.Radom(0, 14);

                p12 = IntUtil.Radom(0, 14);
                p13 = IntUtil.Radom(0, 14);
                p14 = IntUtil.Radom(0, 14);

                // 2 symbol line
                // p1 --> p4     line1
                if (p1 == p4 && line >= 1) { win = (win + 0) + (totalBet * 2); bingoLine1 = 2; }
                // p0 --> p3     line2
                if (p0 == p3 && line >= 2) { win = (win + 0) + (totalBet * 2); bingoLine2 = 2; }
                // p2 --> p5     line3
                if (p2 == p5 && line >= 3) { win = (win + 0) + (totalBet * 2); bingoLine3 = 2; }
                // p0 --> p4     line4
                if (p0 == p4 && line >= 4) { win = (win + 0) + (totalBet * 2); bingoLine4 = 2; }
                // p2 --> p4     line5
                if (p2 == p4 && line >= 5) { win = (win + 0) + (totalBet * 2); bingoLine5 = 2; }
                // p1 --> p5     line6
                if (p1 == p5 && line >= 6) { win = (win + 0) + (totalBet * 2); bingoLine6 = 2; }
                // p1 --> p3     line7
                if (p1 == p3 && line >= 7) { win = (win + 0) + (totalBet * 2); bingoLine7 = 2; }
                // p0 --> p3     line8
                if (p0 == p3 && line >= 8) { win = (win + 0) + (totalBet * 2); bingoLine8 = 2; }
                // p2 --> p5     line9
                if (p2 == p5 && line >= 9) { win = (win + 0) + (totalBet * 2); bingoLine9 = 2; }
                // p0 --> p4     lin10
                if (p0 == p4 && line >= 10) { win = (win + 0) + (totalBet * 2); bingoLine10 = 2; }
                // p2 --> p4     line11
                if (p2 == p4 && line >= 11) { win = (win + 0) + (totalBet * 2); bingoLine11 = 2; }
                // p0 --> p4     lin12
                if (p0 == p4 && line >= 12) { win = (win + 0) + (totalBet * 2); bingoLine12 = 2; }
                // p2 --> p4     lin13
                if (p2 == p4 && line >= 13) { win = (win + 0) + (totalBet * 2); bingoLine13 = 2; }
                // p1 --> p5     lin14
                if (p1 == p5 && line >= 14) { win = (win + 0) + (totalBet * 2); bingoLine14 = 2; }
                // p1 --> p3     lin15
                if (p1 == p3 && line >= 15) { win = (win + 0) + (totalBet * 2); bingoLine15 = 2; }
                // p1 --> p4     lin16
                if (p1 == p4 && line >= 16) { win = (win + 0) + (totalBet * 2); bingoLine16 = 2; }
                // p1 --> p4     lin17
                if (p1 == p4 && line >= 17) { win = (win + 0) + (totalBet * 2); bingoLine17 = 2; }
                // p0 --> p3     lin18
                if (p0 == p3 && line >= 18) { win = (win + 0) + (totalBet * 2); bingoLine18 = 2; }
                // p2 --> p5     lin19
                if (p2 == p5 && line >= 19) { win = (win + 0) + (totalBet * 2); bingoLine19 = 2; }
                // p0 --> p5     lin20
                if (p0 == p5 && line >= 20) { win = (win + 0) + (totalBet * 2); bingoLine20 = 2; }

                // 3 symbol line
                // p1 --> p4 --> p7     line1
                if (p1 == p4 && p4 == p7 && line >= 1) { win = (win + 30) + (totalBet * 2); bingoLine1 = 3; }
                // p0 --> p3 --> p6     line2
                if (p0 == p3 && p3 == p6 && line >= 2) { win = (win + 30) + (totalBet * 2); bingoLine2 = 3; }
                // p2 --> p5 --> p8     line3
                if (p2 == p5 && p5 == p8 && line >= 3) { win = (win + 30) + (totalBet * 2); bingoLine3 = 3; }
                // p0 --> p4 --> p8     line4
                if (p0 == p4 && p4 == p8 && line >= 4) { win = (win + 30) + (totalBet * 2); bingoLine4 = 3; }
                // p2 --> p4 --> p6     line5
                if (p2 == p4 && p4 == p6 && line >= 5) { win = (win + 30) + (totalBet * 2); bingoLine5 = 3; }
                // p1 --> p5 --> p8     line6
                if (p1 == p5 && p5 == p8 && line >= 6) { win = (win + 30) + (totalBet * 2); bingoLine6 = 3; }
                // p1 --> p3 --> p6     line7
                if (p1 == p3 && p3 == p6 && line >= 7) { win = (win + 30) + (totalBet * 2); bingoLine7 = 3; }
                // p0 --> p3 --> p7     line8
                if (p0 == p3 && p3 == p7 && line >= 8) { win = (win + 30) + (totalBet * 2); bingoLine8 = 3; }
                // p2 --> p5 --> p7     line9
                if (p2 == p5 && p5 == p7 && line >= 9) { win = (win + 30) + (totalBet * 2); bingoLine9 = 3; }
                // p0 --> p4 --> p7     lin10
                if (p0 == p4 && p4 == p7 && line >= 10) { win = (win + 30) + (totalBet * 2); bingoLine10 = 3; }
                // p2 --> p4 --> p7     line11
                if (p2 == p4 && p4 == p7 && line >= 11) { win = (win + 30) + (totalBet * 2); bingoLine11 = 3; }
                // p0 --> p4 --> p7     lin12
                if (p0 == p4 && p4 == p7 && line >= 12) { win = (win + 30) + (totalBet * 2); bingoLine12 = 3; }
                // p2 --> p4 --> p7     lin13
                if (p2 == p4 && p4 == p7 && line >= 13) { win = (win + 30) + (totalBet * 2); bingoLine13 = 3; }
                // p1 --> p5 --> p8     lin14
                if (p1 == p5 && p5 == p8 && line >= 14) { win = (win + 30) + (totalBet * 2); bingoLine14 = 3; }
                // p1 --> p3 --> p6     lin15
                if (p1 == p3 && p3 == p6 && line >= 15) { win = (win + 30) + (totalBet * 2); bingoLine15 = 3; }
                // p1 --> p4 --> p8     lin16
                if (p1 == p4 && p4 == p8 && line >= 16) { win = (win + 30) + (totalBet * 2); bingoLine16 = 3; }
                // p1 --> p4 --> p6     lin17
                if (p1 == p4 && p4 == p6 && line >= 17) { win = (win + 30) + (totalBet * 2); bingoLine17 = 3; }
                // p0 --> p3 --> p7     lin18
                if (p0 == p3 && p3 == p7 && line >= 18) { win = (win + 30) + (totalBet * 2); bingoLine18 = 3; }
                // p2 --> p5 --> p7     lin19
                if (p2 == p5 && p5 == p7 && line >= 19) { win = (win + 30) + (totalBet * 2); bingoLine19 = 3; }
                // p0 --> p5 --> p6     lin20
                if (p0 == p5 && p5 == p6 && line >= 20) { win = (win + 30) + (totalBet * 2); bingoLine20 = 3; }

                // 4 symbol line
                // p1 --> p4 --> p7 --> p10     line1
                if (p1 == p4 && p4 == p7 && p7 == p10 && line >= 1) { win = (win + 70) + (totalBet * 2); bingoLine1 = 4; }
                // p0 --> p3 --> p6 --> p9      line2
                if (p0 == p3 && p3 == p6 && p6 == p9 && line >= 2) { win = (win + 70) + (totalBet * 2); bingoLine2 = 4; }
                // p2 --> p5 --> p8 --> p11     line3
                if (p2 == p5 && p5 == p8 && p8 == p11 && line >= 3) { win = (win + 70) + (totalBet * 2); bingoLine3 = 4; }
                // p0 --> p4 --> p8 --> p10     line4
                if (p0 == p4 && p4 == p8 && p8 == p10 && line >= 4) { win = (win + 70) + (totalBet * 2); bingoLine4 = 4; }
                // p2 --> p4 --> p6 --> p10     line5
                if (p2 == p4 && p4 == p6 && p6 == p10 && line >= 5) { win = (win + 70) + (totalBet * 2); bingoLine5 = 4; }
                // p1 --> p5 --> p8 --> p11     line6
                if (p1 == p5 && p5 == p8 && p8 == p11 && line >= 6) { win = (win + 70) + (totalBet * 2); bingoLine6 = 4; }
                // p1 --> p3 --> p6 --> p9      line7
                if (p1 == p3 && p3 == p6 && p6 == p9 && line >= 7) { win = (win + 70) + (totalBet * 2); bingoLine7 = 4; }
                // p0 --> p3 --> p7 --> p11     line8
                if (p0 == p3 && p3 == p7 && p7 == p11 && line >= 8) { win = (win + 70) + (totalBet * 2); bingoLine8 = 4; }
                // p2 --> p5 --> p7 --> p9      line9
                if (p2 == p5 && p5 == p7 && p7 == p9 && line >= 9) { win = (win + 70) + (totalBet * 2); bingoLine9 = 4; }
                // p0 --> p4 --> p7 --> p10     lin10
                if (p0 == p4 && p4 == p7 && p7 == p10 && line >= 10) { win = (win + 70) + (totalBet * 2); bingoLine10 = 4; }
                // p2 --> p4 --> p7 --> p10     line11
                if (p2 == p4 && p4 == p7 && p7 == p10 && line >= 11) { win = (win + 70) + (totalBet * 2); bingoLine11 = 4; }
                // p0 --> p4 --> p7 --> p10     lin12
                if (p0 == p4 && p4 == p7 && p7 == p10 && line >= 12) { win = (win + 70) + (totalBet * 2); bingoLine12 = 4; }
                // p2 --> p4 --> p7 --> p10     lin13
                if (p2 == p4 && p4 == p7 && p7 == p10 && line >= 13) { win = (win + 70) + (totalBet * 2); bingoLine13 = 4; }
                // p1 --> p5 --> p8 --> p10     lin14
                if (p1 == p5 && p5 == p8 && p8 == p10 && line >= 14) { win = (win + 70) + (totalBet * 2); bingoLine14 = 4; }
                // p1 --> p3 --> p6 --> p10     lin15
                if (p1 == p3 && p3 == p6 && p6 == p10 && line >= 15) { win = (win + 70) + (totalBet * 2); bingoLine15 = 4; }
                // p1 --> p4 --> p8 --> p10     lin16
                if (p1 == p4 && p4 == p8 && p8 == p10 && line >= 16) { win = (win + 70) + (totalBet * 2); bingoLine16 = 4; }
                // p1 --> p4 --> p6 --> p10     lin17
                if (p1 == p4 && p4 == p6 && p6 == p10 && line >= 17) { win = (win + 70) + (totalBet * 2); bingoLine17 = 4; }
                // p0 --> p3 --> p7 --> p11     lin18
                if (p0 == p3 && p3 == p7 && p7 == p11 && line >= 18) { win = (win + 70) + (totalBet * 2); bingoLine18 = 4; }
                // p2 --> p5 --> p7 --> p9      lin19
                if (p2 == p5 && p5 == p7 && p7 == p9 && line >= 19) { win = (win + 70) + (totalBet * 2); bingoLine19 = 4; }
                // p0 --> p5 --> p6 --> p11     lin20
                if (p0 == p5 && p5 == p6 && p6 == p11 && line >= 20) { win = (win + 70) + (totalBet * 2); bingoLine20 = 4; }

                // 5 symbol line
                // p1 --> p4 --> p7 --> p10 --> p13     line1
                if (p1 == p4 && p4 == p7 && p7 == p10 && p10 == p13 && line >= 1) { win = (win + 150) + (totalBet * 2); bingoLine1 = 5; }
                // p0 --> p3 --> p6 --> p9 --> p12      line2
                if (p0 == p3 && p3 == p6 && p6 == p9 && p9 == p12 && line >= 2) { win = (win + 150) + (totalBet * 2); bingoLine2 = 5; }
                // p2 --> p5 --> p8 --> p11 --> p14     line3
                if (p2 == p5 && p5 == p8 && p8 == p11 && p11 == p14 && line >= 3) { win = (win + 150) + (totalBet * 2); bingoLine3 = 5; }
                // p0 --> p4 --> p8 --> p10 --> p12     line4
                if (p0 == p4 && p4 == p8 && p8 == p10 && p10 == p12 && line >= 4) { win = (win + 150) + (totalBet * 2); bingoLine4 = 5; }
                // p2 --> p4 --> p6 --> p10 --> p14     line5
                if (p2 == p4 && p4 == p6 && p6 == p10 && p10 == p14 && line >= 5) { win = (win + 150) + (totalBet * 2); bingoLine5 = 5; }
                // p1 --> p5 --> p8 --> p11 --> p13     line6
                if (p1 == p5 && p5 == p8 && p8 == p11 && p11 == p13 && line >= 6) { win = (win + 150) + (totalBet * 2); bingoLine6 = 5; }
                // p1 --> p3 --> p6 --> p9 --> p13      line7
                if (p1 == p3 && p3 == p6 && p6 == p9 && p9 == p13 && line >= 7) { win = (win + 150) + (totalBet * 2); bingoLine7 = 5; }
                // p0 --> p3 --> p7 --> p11 --> p14     line8
                if (p0 == p3 && p3 == p7 && p7 == p11 && p11 == p14 && line >= 8) { win = (win + 150) + (totalBet * 2); bingoLine8 = 5; }
                // p2 --> p5 --> p7 --> p9 --> p12      line9
                if (p2 == p5 && p5 == p7 && p7 == p9 && p9 == p12 && line >= 9) { win = (win + 150) + (totalBet * 2); bingoLine9 = 5; }
                // p0 --> p4 --> p7 --> p10 --> p12     lin10
                if (p0 == p4 && p4 == p7 && p7 == p10 && p10 == p12 && line >= 10) { win = (win + 150) + (totalBet * 2); bingoLine10 = 5; }
                // p2 --> p4 --> p7 --> p10 --> p14     line11
                if (p2 == p4 && p4 == p7 && p7 == p10 && p10 == p14 && line >= 11) { win = (win + 150) + (totalBet * 2); bingoLine11 = 5; }
                // p0 --> p4 --> p7 --> p10 --> p14     lin12
                if (p0 == p4 && p4 == p7 && p7 == p10 && p10 == p14 && line >= 12) { win = (win + 150) + (totalBet * 2); bingoLine12 = 5; }
                // p2 --> p4 --> p7 --> p10 --> p12     lin13
                if (p2 == p4 && p4 == p7 && p7 == p10 && p10 == p12 && line >= 13) { win = (win + 150) + (totalBet * 2); bingoLine13 = 5; }
                // p1 --> p5 --> p8 --> p10 --> p12     lin14
                if (p1 == p5 && p5 == p8 && p8 == p10 && p10 == p12 && line >= 14) { win = (win + 150) + (totalBet * 2); bingoLine14 = 5; }
                // p1 --> p3 --> p6 --> p10 --> p14     lin15
                if (p1 == p3 && p3 == p6 && p6 == p10 && p10 == p14 && line >= 15) { win = (win + 150) + (totalBet * 2); bingoLine15 = 5; }
                // p1 --> p4 --> p8 --> p10 --> p12     lin16
                if (p1 == p4 && p4 == p8 && p8 == p10 && p10 == p12 && line >= 16) { win = (win + 150) + (totalBet * 2); bingoLine16 = 5; }
                // p1 --> p4 --> p6 --> p10 --> p14     lin17
                if (p1 == p4 && p4 == p6 && p6 == p10 && p10 == p14 && line >= 17) { win = (win + 150) + (totalBet * 2); bingoLine17 = 5; }
                // p0 --> p3 --> p7 --> p11 --> p13     lin18
                if (p0 == p3 && p3 == p7 && p7 == p11 && p11 == p13 && line >= 18) { win = (win + 150) + (totalBet * 2); bingoLine18 = 5; }
                // p2 --> p5 --> p7 --> p9 --> p13     lin19
                if (p2 == p5 && p5 == p7 && p7 == p9 && p9 == p13 && line >= 19) { win = (win + 150) + (totalBet * 2); bingoLine19 = 5; }
                // p0 --> p5 --> p6 --> p11 --> p12     lin20
                if (p0 == p5 && p5 == p6 && p6 == p11 && p11 == p12 && line >= 20) { win = (win + 150) + (totalBet * 2); bingoLine20 = 5; }
                //


                //
                credits = credits + win;
                totalBet = line * bet;

                //var query = from o in db.Members
                //            select o;
                //List<Member> dataList = query.ToList();

                Member mem = db.Members.Find(memberId);
                GameRecord gam = db.GameRecords.Find(memberId);
                gam.betPoint =totalBet;
                gam.betResult =win;
                gam.gameId = 1;
                gam.bet_time= DateTime.Now.ToString("yyyy/MM/dd hh:mm");
                gam.memberId = memberId;
                db.GameRecords.Add(gam);
                mem.pocketPoint = credits;
                db.SaveChanges();
            }

            Clients.Caller.getNewSymbol(
                p0, p1, p2,
                p3, p4, p5,
                p6, p7, p8,
                p9, p10, p11,
                p12, p13, p14,
                bingoLine1, bingoLine2,
                bingoLine3, bingoLine4, bingoLine5,
                bingoLine6, bingoLine7, bingoLine8,
                bingoLine9, bingoLine10, bingoLine11,
                bingoLine12, bingoLine13, bingoLine14,
                bingoLine15, bingoLine16, bingoLine17,
                bingoLine18, bingoLine19, bingoLine20,
                credits, win, bet, line, totalBet);
        }
        //public void Update(int bet, int line, int totalBet) {
        //    totalBet = line * bet;
        //    Clients.Caller.updateEumn(bet,line,totalBet);
        //}


        public static class IntUtil
        {
            private static Random random;

            private static void Init()
            {
                if (random == null)
                {
                    random = new Random();
                }
            }
            public static int Radom(int min, int max)
            {
                Init();
                return random.Next(min, max);
            }

        }

    }
}