package abstractions.services;

import infrastructure.models.Music;

import java.util.List;
import java.util.Optional;

public interface IMusicService {
    Music createMusic(Music music);
    List<Music> getAllMusic();
    Optional<Music> getMusicById(String id);

    /*
        @author Slava
        Task: need to realize delete and update Music
        Logic: find music by id and after delete or update
    */
    void deleteMusic(String id);
    Music updateMusic(Music music); // @author Slava
}
