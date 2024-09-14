package com.example.MusicMicroservice.infrastructure.services;

import com.example.MusicMicroservice.infrastructure.abstractions.StorageService;
import com.example.MusicMicroservice.infrastructure.exceptions.StorageException;
import com.example.MusicMicroservice.infrastructure.storage.StorageProperties;
import jakarta.annotation.PostConstruct;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.io.Resource;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.io.InputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.stream.Stream;

@Service
public class FileSystemStorageService implements StorageService {

    private final Path rootLocation;

    @Autowired
    public FileSystemStorageService(StorageProperties properties){
        this.rootLocation = Paths.get(properties.getLocation());
    }

    @Override
    @PostConstruct
    public void init() {
        try {
            Files.createDirectories(rootLocation);
        } catch (IOException ex){
            throw new StorageException("info");
        }
    }

    @Override
    public String store(MultipartFile file) {

        String filename = StringUtils.cleanPath(file.getOriginalFilename());
        if(file.isEmpty()){ return "empty error";}

        if(filename.contains("..")) {
            throw new StorageException("contains error");
        }

        try (InputStream inputStream = file.getInputStream()){
            Files.copy(inputStream, this.rootLocation.resolve(filename),
                    StandardCopyOption.REPLACE_EXISTING);
        }
        catch(IOException e){
            throw new StorageException("info", e);
        }

        return filename;
    }

    @Override
    public Stream<Path> loadAll() {
        try{
            return Files.walk(this.rootLocation, 1)
                    .filter(path -> !path.equals(this.rootLocation))
                    .map(this.rootLocation::relativize);
        } catch (IOException e){
            throw new StorageException("info", e);
        }
    }

    @Override
    public Path load(String fileName) {
        return null;
    }

    @Override
    public Resource loadAsResource() {
        return null;
    }

    @Override
    public void deleteAll() {

    }
}
