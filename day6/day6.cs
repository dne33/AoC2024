using System;
using System.Collections.Generic;
static List<(int, int)> get_travelled(int direction, (int, int) agent_post, List<(int, int)> blockers, int lines, int cols) {
    List<(int, int)> travelled = new List<(int, int)>(); 
    if (direction == 0) {
        // Going up
        List<(int, int)> filteredList = blockers.Where(x => agent_post.Item2 == x.Item2 && agent_post.Item1 > x.Item1).ToList();
       
        (int, int) closest = (0,0);
        if (filteredList.Count == 0) {
            closest = (-1, agent_post.Item2);  
        } else {
            closest = filteredList.OrderByDescending(t => t.Item1).First();
        }
        for (int i = agent_post.Item1; i > closest.Item1; i-- ) {
            travelled.Add((i, agent_post.Item2));
        }
        return travelled;
            

    } else if (direction == 1) {
        // Going right
        List<(int, int)> filteredList = blockers.Where(x => agent_post.Item1 == x.Item1 && agent_post.Item2 < x.Item2).ToList();
        (int, int) closest = (0,0);
        if (filteredList.Count == 0) {
            closest = (agent_post.Item1, cols);  
        } else {
            closest = filteredList.OrderByDescending(t => t.Item2).Last();
        }
        for (int i = agent_post.Item2; i < closest.Item2; i++ ) {
            travelled.Add((agent_post.Item1, i));
        }
        return travelled;
        

    } else if (direction == 2) {
        // Going down
        List<(int, int)> filteredList = blockers.Where(x => agent_post.Item2 == x.Item2 && agent_post.Item1 < x.Item1).ToList();
       
        (int, int) closest = (0,0);
        if (filteredList.Count == 0) {
            closest = (lines, agent_post.Item2);  
        } else {
            closest = filteredList.OrderByDescending(t => t.Item1).Last();
        }
        for (int i = agent_post.Item1; i < closest.Item1; i++ ) {
            travelled.Add((i, agent_post.Item2));
        }
        return travelled;

    } else if (direction == 3) {
        // Going left
        List<(int, int)> filteredList = blockers.Where(x => agent_post.Item1 == x.Item1 && agent_post.Item2 > x.Item2).ToList();
       
        (int, int) closest = (0,0);
        if (filteredList.Count == 0) {
            closest = (agent_post.Item1, -1);  
        } else {
            closest = filteredList.OrderByDescending(t => t.Item2).First();
        }
        for (int i = agent_post.Item2; i > closest.Item2; i-- ) {
            travelled.Add((agent_post.Item1, i));
        }
        return travelled;
        

    }
    return travelled;
}

static int part1() {
     using (StreamReader reader = new StreamReader("input.txt"))
        {
            string line;
            int count = 0;
            int lines = 0;
            char hash = '#';
            char dot = '.';
            List<char> agent = new List<char>() {'^', '>', 'v', '<' };
            (int, int) agent_pos = (0,0);
            int direction = 0;
            int amt_cols = 0;
            List<(int, int)> blockers = new List<(int, int)>(); 
            HashSet<(int, int)> crossed = new HashSet<(int, int)>(); 

            while ((line = reader.ReadLine()) != null)
            {
                char[] charList = line.ToCharArray();
                int col = 0;
                foreach (char item in charList)
                {
                   if (item != dot) {
                    if (item == hash) {
                        blockers.Add((lines, col));
                    } else {
                        agent_pos = ((lines, col));
                        direction = agent.IndexOf(item);
                    }
                   }  
                   col++;
                }
                amt_cols = col;
                lines++;
            }
            foreach (var blocker in blockers)
            {
                Console.WriteLine($"Blocker: ({blocker.Item1}, {blocker.Item2})");
            }
            HashSet<(int, int)> unique_stops = new HashSet<(int, int)>();
            List<(int, int)> all_stops = new List<(int, int)>();
        
            while (true) {
                
                all_stops = get_travelled(direction, agent_pos, blockers, lines, amt_cols);
                foreach (var blocker in all_stops)
                {
                    Console.WriteLine($"filteredList: ({blocker.Item1}, {blocker.Item2})");
                }
                agent_pos = all_stops[all_stops.Count - 1];
                
                direction = (direction + 1) % 4;
                Console.WriteLine($"pos: ({agent_pos.Item1}, {agent_pos.Item2})");
                Console.WriteLine(direction);
                unique_stops.UnionWith(all_stops); 
                if (agent_pos.Item1 == 0 || agent_pos.Item2 == 0 || agent_pos.Item1 == lines-1 || agent_pos.Item2 == amt_cols-1) {
                    break;
                }
            }
            foreach (var blocker in unique_stops)
                {
                    Console.WriteLine($"Unique Stops: (| {blocker.Item1}, - {blocker.Item2})");
                }
            return unique_stops.Count;
        }
    return 0;
}




static int part2() {
    using (StreamReader reader = new StreamReader("input.txt"))
        {
            string line;
            
            int count = 0;
            while ((line = reader.ReadLine()) != null)
            {
                
            }
            return count;
        }
    return 0;
}

Console.WriteLine(part1());
Console.WriteLine(part2());

