namespace MovieCrud_EF.Models;

public class MovieCrud
{
    ApplicationDbContext context;
    private IConfiguration configuration;

    public MovieCrud(ApplicationDbContext context)
    {
        this.context = context;
    }

    public MovieCrud(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<Movie> GetMovies()
    {
        return context.Movies.Where(x => x.IsActive == 1).ToList();
    }


    public Movie GetMovieById(int id)
    {
        var mov = context.Movies.Where(x => x.Id == id).FirstOrDefault();
        return mov;
    }


    public int AddMovie(Movie mov)
    {
        mov.IsActive = 1;
        int result = 0;
        context.Movies.Add(mov); // add new record in to the DbSet
        result = context.SaveChanges(); // update the change from DbSet to DB
        return result;
    }
    public int UpdateMovie(Movie mov)
    {

        int result = 0;
        // search from dbset
        var b = context.Movies.Where(x => x.Id == mov.Id).FirstOrDefault();
        if (b != null)
        {
            b.Mname = mov.Mname; // b object contains old data book obj contains new data
            b.ReleaseDate = mov.ReleaseDate;
            b.Genre = mov.Genre;
            b.StarsName= mov.StarsName;
            b.IsActive = 1;
            result = context.SaveChanges(); // update the change from DbSet to DB
        }

        return result;
    }
    public int DeleteMovie(int id)
    {
        int result = 0;
        // search from dbset
        var b = context.Movies.Where(x => x.Id == id).FirstOrDefault();
        if (b != null)
        {
            b.IsActive = 0;
            result = context.SaveChanges(); // update the change from DbSet to DB
        }
        return result;
    }
}

