using AdminNamespace;
using UserNamespace;
using PostNamespace;
using NotificationNamespace;

class Program
{
    static List<Admin> admins = new List<Admin>();
    static List<User> users = new List<User>();
    static List<Post> posts = new List<Post>();
    static List<Notification> notifications = new List<Notification>();

    static void Main(string[] args)
    {
        Admin admin = new Admin(1, "Anar", "Anar@gmail.com", "1234");
        admins.Add(admin);

        User user = new User(1, "User", "Example", 25, "user@example.com", "user");
        users.Add(user);

        Post post = new Post(1, "Sample Post");
        posts.Add(post);
        admin.Posts.Add(post);

        while (true)
        {
            Console.WriteLine("Giriş edin (1- User, 2- Admin): ");
            int userType = int.Parse(Console.ReadLine());

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            if (userType == 1)
            {
                var user1 = users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user1 != null)
                {
                    UserMenu(user1);
                }
                else
                {
                    Console.WriteLine("Email ve ya sifre yanlisdir.");
                }
            }
            else if (userType == 2)
            {
                var admin1 = admins.FirstOrDefault(a => a.Email == email && a.Password == password);
                if (admin1 != null)
                {
                    AdminMenu(admin1);
                }
                else
                {
                    Console.WriteLine("Email ve ya sifre yanlisdir.");
                }
            }
        }
    }
    static void UserMenu(User user)
    {
        while (true)
        {
            Console.WriteLine("1- Postlara Bax, 2- Post Beyen, 3- Çıkış");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 3) break;

            switch (choice)
            {
                case 1:
                    ViewPosts(user);
                    break;
                case 2:
                    LikePost(user);
                    break;
                default:
                    Console.WriteLine("Secim movcud deil.");
                    break;
            }
        }
    }

    static void AdminMenu(Admin admin)
    {
        while (true)
        {
            Console.WriteLine("1- Bildirimleri Görüntüle, 2- Çıkış");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 2) break;

            if (choice == 1)
                ViewNotifications(admin);
            else
                Console.WriteLine("Secim movcud deil.");
        }
    }

    static void ViewPosts(User user)
    {
        foreach (var post in posts)
        {
            Console.WriteLine($"ID: {post.Id}, Post: {post.Content}, Beyeni Sayı: {post.LikeCount}, Görüntüleme Sayı: {post.ViewCount}");
        }

        Console.WriteLine("Görmek istediğiniz postun ID'sini daxil edin: ");
        int postId = int.Parse(Console.ReadLine());

        var selectedPost = posts.Find(p => p.Id == postId);
        if (selectedPost != null)
        {
            selectedPost.ViewCount++;
            NotifyAdmin(selectedPost.Id, user, "Post görüntülendi");
            Console.WriteLine($"Post ID {selectedPost.Id} görüntülendi. Görüntülenme Sayı: {selectedPost.ViewCount}");
        }
        else
        {
            Console.WriteLine("Post movcud deil.");
        }
    }

    static void LikePost(User user)
    {
        foreach (var post1 in posts)
        {
            Console.WriteLine($"ID: {post1.Id}, Post: {post1.Content}, Beyeni Sayı: {post1.LikeCount}, Görüntüleme Sayı: {post1.ViewCount}");
        }
        Console.WriteLine("Beyenmek istediğiniz postun ID'sini daxil edin: ");
        int postId = int.Parse(Console.ReadLine());

        var post = posts.Find(p => p.Id == postId);
        if (post != null)
        {
            post.LikeCount++;
            NotifyAdmin(postId, user, "Post beyenildi");
            Console.WriteLine("Post beyenildi.");
        }
        else
        {
            Console.WriteLine("Post movcud deil.");
        }
    }

    static void NotifyAdmin(int postId, User user, string action)
    {
        var admin = admins[0];
        var notification = new Notification(
            notifications.Count + 1,
            $"Post ID {postId} {action}",
            DateTime.Now,
            user
        );
        admin.Notifications.Add(notification);
        notifications.Add(notification);
    }

    static void ViewNotifications(Admin admin)
    {
        foreach (var notification in admin.Notifications)
        {
            var user = notification.FromUser != null ? notification.FromUser.Name : "Anonim";
            Console.WriteLine($"Bildirim: {notification.Text}, Tarih: {notification.DateTime}, Kullanıcı: {user}");
        }
    }
}
