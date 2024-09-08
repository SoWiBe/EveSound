package com.example.MusicMicroservice.infrastructure.abstractions;

import org.springframework.core.io.Resource;
import org.springframework.web.multipart.MultipartFile;

import java.nio.file.Path;
import java.util.stream.Stream;

public interface StorageService {

    void init();
    String store(MultipartFile file);
    Stream<Path> loadAll();
    Path load(String fileName);
    Resource loadAsResource();
    void deleteAll();
}
