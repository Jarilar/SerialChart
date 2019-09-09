#include "myiic.h"
#include "delay.h"


//��ʼ��IIC
//��ʼ��IIC
void IIC_Init(void)
{					     
	GPIO_InitTypeDef  GPIO_InitStructure;

  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);//ʹ��GPIOBʱ��

  //GPIOB8,B9��ʼ������
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_8 | GPIO_Pin_9;
  //GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;//��ͨ���ģʽ
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;//�������
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;//100MHz
  //GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;//����
  GPIO_Init(GPIOB, &GPIO_InitStructure);//��ʼ��
	IIC_SCL=1;
	IIC_SDA=1;

}
//����IIC��ʼ�ź�
void IIC_Start(void)
{
	SDA_OUT();                                                                 //sda�����
	IIC_SDA=1;	  	  
	IIC_SCL=1;
	delay_us(4);
 	IIC_SDA=0;                                                                 //START:when CLK is high,DATA change form high to low 
	delay_us(4);
	IIC_SCL=0;                                                                 //ǯסI2C���ߣ�׼�����ͻ�������� 
}	  
//����IICֹͣ�ź�
void IIC_Stop(void)
{
	SDA_OUT();                                                                 //sda�����
	IIC_SCL=0;
	IIC_SDA=0;                                                                 //STOP:when CLK is high DATA change form low to high
 	delay_us(4);
	IIC_SCL=1; 
	IIC_SDA=1;                                                                 //����I2C���߽����ź�
	delay_us(4);							   	
}
//�ȴ�Ӧ���źŵ���
//����ֵ��1������Ӧ��ʧ��
//        0������Ӧ��ɹ�
u8 IIC_Wait_Ack(void)
{
	u8 ucErrTime=0;
	SDA_IN();                                                                  //SDA����Ϊ����  
	IIC_SDA=1;delay_us(1);	   
	IIC_SCL=1;delay_us(1);	 
	while(READ_SDA)
	{
		ucErrTime++;
		if(ucErrTime>250)
		{
			IIC_Stop();
			return 1;
		}
	}
	IIC_SCL=0;                                                                 //ʱ�����0 	   
	return 0;  
} 
//����ACKӦ��
void IIC_Ack(void)
{
	IIC_SCL=0;
	SDA_OUT();
	IIC_SDA=0;
	delay_us(2);
	IIC_SCL=1;
	delay_us(2);
	IIC_SCL=0;
}
//������ACKӦ��		    
void IIC_NAck(void)
{
	IIC_SCL=0;
	SDA_OUT();
	IIC_SDA=1;
	delay_us(2);
	IIC_SCL=1;
	delay_us(2);
	IIC_SCL=0;
}					 				     
//IIC����һ���ֽ�
//���شӻ�����Ӧ��
//1����Ӧ��
//0����Ӧ��			  
void IIC_Send_Byte(u8 txd)
{                        
    u8 t;   
	SDA_OUT(); 	    
    IIC_SCL=0;                                                                 //����ʱ�ӿ�ʼ���ݴ���
    for(t=0;t<8;t++)
    {              
        IIC_SDA=(txd&0x80)>>7;
        txd<<=1; 	  
		delay_us(2);                                                           //��TEA5767��������ʱ���Ǳ����
		IIC_SCL=1;
		delay_us(2); 
		IIC_SCL=0;	
		delay_us(2);
    }	 
} 	    
//��1���ֽڣ�ack=1ʱ������ACK��ack=0������nACK   
u8 IIC_Read_Byte(unsigned char ack)
{
	unsigned char i,receive=0;
	SDA_IN();                                                                  //SDA����Ϊ����
    for(i=0;i<8;i++ )
	{
        IIC_SCL=0; 
        delay_us(2);
		IIC_SCL=1;
        receive<<=1;
        if(READ_SDA)receive++;   
		delay_us(1); 
    }					 
    if (!ack)
        IIC_NAck();                                                            //����nACK
    else
        IIC_Ack();                                                             //����ACK   
    return receive;
}

//��ָ����ַ����һ������
//ReadAddr:��ʼ�����ĵ�ַ  
//����ֵ  :����������
u8 iicDevReadByte(u8 devaddr,u8 addr)
{				  
	u8 temp=0;		  	    																 
	IIC_Start();  
	IIC_Send_Byte(devaddr);                                                    //��������д���� 	   
	IIC_Wait_Ack(); 
	IIC_Send_Byte(addr);                                                       //���͵͵�ַ
	IIC_Wait_Ack();	

	IIC_Start();  	 	   
	IIC_Send_Byte(devaddr|1);                                                  //��������������			   
	IIC_Wait_Ack();	 
	temp=IIC_Read_Byte(0);			   
	IIC_Stop();                                                                //����һ��ֹͣ����	    
	return temp;
}

//����������ֽ�
//addr:��ʼ��ַ
//rbuf:�����ݻ���
//len:���ݳ���
void iicDevRead(u8 devaddr,u8 addr,u8 len,u8 *rbuf)
{
	int i=0;
	IIC_Start();  
	IIC_Send_Byte(devaddr);  
	IIC_Wait_Ack();	
	IIC_Send_Byte(addr);                                                       //��ַ����  
	IIC_Wait_Ack();	

	IIC_Start();  	
	IIC_Send_Byte(devaddr|1);  	
	IIC_Wait_Ack();	
	for(i=0; i<len; i++)
	{
		if(i==len-1)
		{
			rbuf[i]=IIC_Read_Byte(0);                                          //���һ���ֽڲ�Ӧ��
		}
		else
			rbuf[i]=IIC_Read_Byte(1);
	}
	IIC_Stop( );	
}


void iicDevReadCal1(u8 devaddr,u8 addr,u8 len,u8 *rbuf)
{
	int i=0;
	IIC_Start();  
	IIC_Send_Byte(devaddr);  
	IIC_Wait_Ack();	
	IIC_Send_Byte(0x88);                                                       //��ַ����  
	IIC_Wait_Ack();	
	len=24;
	for(i=0; i<len; i++)
	{
		if(i==len-1)
		{
			rbuf[i]=IIC_Read_Byte(0);                                          //���һ���ֽڲ�Ӧ��
		}
		else
			rbuf[i]=IIC_Read_Byte(1);
	}
	IIC_Stop( );	
	delay_us(100);
	
	IIC_Start();  
	IIC_Send_Byte(0x76);  
	IIC_Wait_Ack();	
	IIC_Send_Byte(0xA1);                                                       //��ַ����  
	IIC_Wait_Ack();	
	rbuf[i++]=IIC_Read_Byte(0); 
	IIC_Stop( );
	delay_us(100);
	
	IIC_Start();  
	IIC_Send_Byte(0x76);  
	IIC_Wait_Ack();	
	IIC_Send_Byte(0xE1);                                                       //��ַ����  
	IIC_Wait_Ack();	
	len=32;
	for(; i<len; i++)
	{
		if(i==len-1)
		{
			rbuf[i]=IIC_Read_Byte(0);                                          //���һ���ֽڲ�Ӧ��
		}
		else
			rbuf[i]=IIC_Read_Byte(1);
	}
	IIC_Stop( );	
}

//����������ֽ�
//addr:��ʼ��ַ
//rbuf:�����ݻ���
//len:���ݳ���
void iicDevReadCal(u8 devaddr,u8 addr,u8 len,bme280Calib *bme280Ctype)
{
	int i=0;
	u8 rbuf[32];
	IIC_Start();  
	IIC_Send_Byte(devaddr);  
	IIC_Wait_Ack();	
	IIC_Send_Byte(0x88);                                                       //��ַ����  
	IIC_Wait_Ack();	
	len=24;
	for(i=0; i<len; i++)
	{
		if(i==len-1)
		{
			rbuf[i]=IIC_Read_Byte(0);                                          //���һ���ֽڲ�Ӧ��
		}
		else
			rbuf[i]=IIC_Read_Byte(1);
	}
	IIC_Stop( );	
	delay_us(100);
	
	IIC_Start();  
	IIC_Send_Byte(devaddr);  
	IIC_Wait_Ack();	
	IIC_Send_Byte(0xA1);                                                       //��ַ����  
	IIC_Wait_Ack();	
	rbuf[i++]=IIC_Read_Byte(0); 
	IIC_Stop( );
	delay_us(100);
	
	IIC_Start();  
	IIC_Send_Byte(devaddr);  
	IIC_Wait_Ack();	
	IIC_Send_Byte(0xE1);                                                       //��ַ����  
	IIC_Wait_Ack();	
	len=32;
	for(; i<len; i++)
	{
		if(i==len-1)
		{
			rbuf[i]=IIC_Read_Byte(0);                                          //���һ���ֽڲ�Ӧ��
		}
		else
			rbuf[i]=IIC_Read_Byte(1);
	}
	IIC_Stop( );
	
	bme280Ctype->dig_T1=(rbuf[1] << 8) | rbuf[0];
	bme280Ctype->dig_T2=(rbuf[3] << 8) | rbuf[2];
	bme280Ctype->dig_T3=(rbuf[5] << 8) | rbuf[4];
	bme280Ctype->dig_P1=(rbuf[7] << 8) | rbuf[6];
	bme280Ctype->dig_P2=(rbuf[9] << 8) | rbuf[8];
	bme280Ctype->dig_P3=(rbuf[11]<< 8) | rbuf[10];
	bme280Ctype->dig_P4=(rbuf[13]<< 8) | rbuf[12];
	bme280Ctype->dig_P5=(rbuf[15]<< 8) | rbuf[14];
	bme280Ctype->dig_P6=(rbuf[17]<< 8) | rbuf[16];
	bme280Ctype->dig_P7=(rbuf[19]<< 8) | rbuf[18];
	bme280Ctype->dig_P8=(rbuf[21]<< 8) | rbuf[20];
	bme280Ctype->dig_P9=(rbuf[23]<< 8) | rbuf[22];
	bme280Ctype->dig_H1=rbuf[24];
	bme280Ctype->dig_H2=(rbuf[26]<< 8) | rbuf[25];
	bme280Ctype->dig_H3=rbuf[27];
	bme280Ctype->dig_H4=(rbuf[28]<< 4) | (0x0F & rbuf[29]);
	bme280Ctype->dig_H5=(rbuf[30] << 4) | ((rbuf[29] >> 4) & 0x0F);
	bme280Ctype->dig_H6=rbuf[31];  
}

//��ָ����ַд��һ������
//WriteAddr :д�����ݵ�Ŀ�ĵ�ַ    
//DataToWrite:Ҫд�������
void iicDevWriteByte(u8 devaddr,u8 addr,u8 data)
{				   	  	    																 
	IIC_Start();  
	IIC_Send_Byte(devaddr);                                                    //��������д���� 	 
	IIC_Wait_Ack();	   
	IIC_Send_Byte(addr);                                                       //���͵͵�ַ
	IIC_Wait_Ack(); 	 										  		   
	IIC_Send_Byte(data);                                                       //�����ֽ�							   
	IIC_Wait_Ack();  		    	   
	IIC_Stop();		                                                           //����һ��ֹͣ���� 	 
}

//����д����ֽ�
//addr:��ʼ��ַ
//wbuf:д���ݻ���
//len:���ݵĳ���
void iicDevWrite(u8 devaddr,u8 addr,u8 len,u8 *wbuf)
{
	int i=0;
	IIC_Start();  
	IIC_Send_Byte(devaddr);  	
	IIC_Wait_Ack();	
	IIC_Send_Byte(addr);  //��ַ����
	IIC_Wait_Ack();	
	for(i=0; i<len; i++)
	{
		IIC_Send_Byte(wbuf[i]);  
		IIC_Wait_Ack();		
	}
	IIC_Stop( );	
}




























