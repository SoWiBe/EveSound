package com.example.MusicMicroservice.infrastructure.services;

import com.example.MusicMicroservice.infrastructure.abstractions.IMusicService;
import com.example.MusicMicroservice.infrastructure.abstractions.repository.IMusicRepository;
import com.example.MusicMicroservice.infrastructure.models.Music;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Collections;
import java.util.List;
import java.util.Optional;

@Service
public class MusicService implements IMusicService {

    private final IMusicRepository musicRepository;

    @Autowired
    public MusicService(IMusicRepository musicRepository) {
        this.musicRepository = musicRepository;
    }

    @Override
    public Music createMusic(Music music) {
        return musicRepository.save(music);
    }

    @Override
    public List<Music> getAllMusic() {
        return musicRepository.findAll();
    }

    @Override
    public Optional<Music> getMusicById(String id) {
        return musicRepository.findById(id);
    }

    @Override
    public void deleteMusic(String id) {
        musicRepository.deleteById(id);
    }

    @Override
    public void deleteAllMusic() {
        musicRepository.deleteAll();
    }

    @Override
    public Music updateMusic(Music music) {
        return musicRepository.save(music);
    }

    @Override
    public List<Music> shuffleMusic(List<Music> music) {
        Collections.shuffle(music);
        return music;
    }

    @Override
    public String play(String idMusic, String idUser) {
        var musicResult = getMusicById(idMusic);
        var music = musicResult.get(); //получение музыки
        music.setPlayed(true); //установка значение запуска трека
        updateMusic(music); //обновление музыки
        return "success";
    }
}
