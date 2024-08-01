package com.example.MusicMicroservice.infrastructure.abstractions.repository;

import com.example.MusicMicroservice.infrastructure.models.Music;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface IMusicRepository extends MongoRepository<Music, String> {
}
