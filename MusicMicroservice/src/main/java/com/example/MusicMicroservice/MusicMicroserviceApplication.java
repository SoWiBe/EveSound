package com.example.MusicMicroservice;

import com.example.MusicMicroservice.infrastructure.storage.StorageProperties;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@SpringBootApplication
@EnableConfigurationProperties(StorageProperties.class)
public class MusicMicroserviceApplication {

	public static void main(String[] args) {
		SpringApplication.run(MusicMicroserviceApplication.class, args);
	}

}
